using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using GBI.EP.Core.Attribute;
using GBI.EP.JanusClient.JanusEntities;
using NPOI.OpenXmlFormats.Spreadsheet;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WebGrease.Css.Extensions;

namespace GBI.EP.Source.Website.Library
{
    public static class NpoiExtension
    {
        public static IRow AppendRow(this ISheet sheet)
        {
            return sheet.CreateRow(sheet.LastRowNum + 1);
        }
    }
    public class ExportMetaData
    {
        public string ExportNotice { get; set; }
    }

    public class CellConvertor
    {
        public Func<object, string> _Convert;

    }
    public class Export
    {
        private ExportMetaData ExportMetaData { get; set; }
        //private IEnumerable<CellConvertor> Convertors { get; set; }
        private static Dictionary<Type, Func<object, string>> _Convertor;

        static Export()
        {
            _Convertor = new Dictionary<Type, Func<object, string>>();
            _Convertor.Add(typeof(List<KeyValuePair<string, string>>), value =>
            {
                return (value as List<KeyValuePair<string, string>>) == null ||
                                   (!(value as List<KeyValuePair<string, string>>).Any())
                                ? ""
                                : (value as List<KeyValuePair<string, string>>).Select(
                                    t => t.Key + ", " + t.Value)
                                    .Aggregate((current, next) => current + ";" + next);
            });
            _Convertor.Add(typeof(IEnumerable<string>), value =>
            {
                return (value as IEnumerable<string>) == null || (!((IEnumerable<string>) value).Any())
                                ? string.Empty
                                : ((IEnumerable<string>) value)
                                    .Aggregate((current, next) => current + ";" + next);
            });
            _Convertor.Add(typeof(IJanusSupportedLanguageDictionary), value =>
            {
                var cn = (value as IJanusSupportedLanguageDictionary).Cn;
                var en = (value as IJanusSupportedLanguageDictionary).En;
                if ((!string.IsNullOrWhiteSpace(cn)) && !string.IsNullOrWhiteSpace(en))
                {
                    return string.Format("{0}, {1}", en, cn);
                }
                if ((!string.IsNullOrWhiteSpace(cn)))
                {
                    return cn;
                }
                return en;
            });
            _Convertor.Add(typeof(DateTime?), value =>
            {
                return ((DateTime?)value).ToString();
            });
            _Convertor.Add(typeof(int?), value =>
            {
                return ((int?)value).ToString();
            });
        }

        public Export():this(new ExportMetaData(){ExportNotice = Resources.Common.EXPORTNOTICE})
        {
        }
        Export(ExportMetaData exportMetaData)
        {
            ExportMetaData = exportMetaData;
        }
        public MemoryStream ExportToStream(IEnumerable<string> headers, IEnumerable<IEnumerable<string>> bodyRows)
        {
            //set layout, set sheet name, set metadata
            XSSFWorkbook book = new XSSFWorkbook();
            ISheet currentSheet = book.CreateSheet("Sheet1");
            IRow rowLayout = currentSheet.CreateRow(0);
            rowLayout.CreateCell(0).SetCellValue(this.ExportMetaData.ExportNotice);

            IRow headerRow = currentSheet.AppendRow();

            headers.ForEach((str, i) => headerRow.CreateCell(i).SetCellValue(str));

            bodyRows.ForEach((bodyRow, bodyRowIndex) =>
            {
                IRow currentBodyRow = currentSheet.AppendRow();
                bodyRow.ForEach((value, columnIndex) => currentBodyRow.CreateCell(columnIndex).SetCellValue(value));
            });
            MemoryStream ms = new MemoryStream();
            book.Write(ms);

            return ms;

        }
        public MemoryStream ExportToStream<T>(IEnumerable<T> enumerableObj)
        {
            Type type = typeof(T);

            var l1 = typeof (T).GetProperties().Where(t =>
                t.CustomAttributes.Any(
                    t1 => t1.AttributeType == typeof (GlobalResourceMappingAttribute)
                    )).ToList();
            foreach (var VARIABLE in l1)
            {
                var x = ResourceHelper.ConvertToGlobalResourceValue(type, VARIABLE);
            }

            var headers = typeof (T).GetProperties().Where(t =>
                t.CustomAttributes.Any(
                    t1 => t1.AttributeType == typeof(GlobalResourceMappingAttribute)
                    )).ToList().Select(t => ResourceHelper.ConvertToGlobalResourceValue(type, t).ToString());
            var bodyRows = enumerableObj.Select(element => typeof (T).GetProperties().Where(t =>
                t.CustomAttributes.Any(
                    t1 => t1.AttributeType == typeof(GlobalResourceMappingAttribute)
                    )).Select(member =>
                    {
                        var value = type.GetProperty(member.Name).GetValue(element);
                        if (value == null)
                        {
                            return "";
                        }

                        var tryGetFromConvertor = TryGetFromConvertor(value);
                        if (tryGetFromConvertor.Item1)
                        {
                            return tryGetFromConvertor.Item2;
                        }

                        return value.ToString();
                    }));

            return ExportToStream(headers, bodyRows);
        }

        private Tuple<bool, string> TryGetFromConvertor(object value)
        {
            if (_Convertor.Any(t => t.Key.IsAssignableFrom(value.GetType())))
            {
                return new Tuple<bool, string>(true,
                    _Convertor.First(t => t.Key.IsAssignableFrom(value.GetType())).Value(value));
            }
            return new Tuple<bool, string>(false, null);
        }
    }
}