using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public ActionResult Index()
        {
            return View();
        }


        //public FileResult Export(string keyword = "", string filter = "", string order = "", string validCount = "")
        //{
        //    string userId = User.Id.ToString();
        //    var actualCount = AppUtility.GetUserExportCount(userId);
        //    var exportCount = validCount.ToInt() <= actualCount.ToInt() ? validCount : actualCount;
        //    var registrationExport = Model.ExportRegistrationInfoToExcel(keyword, filter, order, exportCount);
        //    XSSFWorkbook book = new XSSFWorkbook();
        //    NPOI.SS.UserModel.ISheet sheet1 = book.CreateSheet("Sheet1");
        //    NPOI.SS.UserModel.IRow row0 = sheet1.CreateRow(0);
        //    NPOI.SS.UserModel.IRow row1 = sheet1.CreateRow(1);
        //    row0.CreateCell(0).SetCellValue(Resources.Common.EXPORTNOTICE);
        //    row1.CreateCell(0).SetCellValue(Resources.Registration.APPROVAL_NUMBER);
        //    row1.CreateCell(1).SetCellValue(Resources.Registration.PRODUCT_NAME);
        //    row1.CreateCell(2).SetCellValue(Resources.Registration.PRODUCT_NAME_RAW_DATA);
        //    row1.CreateCell(3).SetCellValue(Resources.Registration.BRAND_NAME);
        //    row1.CreateCell(4).SetCellValue(Resources.Registration.BRAND_NAME_RAW_DATA);
        //    row1.CreateCell(5).SetCellValue(Resources.Registration.REGISTRANT);
        //    row1.CreateCell(6).SetCellValue(Resources.Registration.REGISTRANT_RAW_DATA);
        //    row1.CreateCell(7).SetCellValue(Resources.Registration.ORIGIN);
        //    row1.CreateCell(8).SetCellValue(Resources.Registration.FORMULATION);
        //    row1.CreateCell(9).SetCellValue(Resources.Registration.FORMULATION_RAW_DATA);
        //    row1.CreateCell(10).SetCellValue(Resources.Registration.SPECIFICATION);
        //    row1.CreateCell(11).SetCellValue(Resources.Registration.MANUFACTURER_RAW_DATA);
        //    row1.CreateCell(12).SetCellValue(Resources.Registration.REPACKAGING_COMPANY_RAW_DATA);
        //    row1.CreateCell(13).SetCellValue(Resources.Registration.APPROVAL_DATE);
        //    row1.CreateCell(14).SetCellValue(Resources.Registration.EXPIRATION_DATE);
        //    row1.CreateCell(15).SetCellValue(Resources.Registration.VALIDITY);
        //    row1.CreateCell(16).SetCellValue(Resources.Registration.DRUG_TYPE);
        //    row1.CreateCell(17).SetCellValue(Resources.Registration.PACKAGE);
        //    //....N行  
        //    XSSFCellStyle cellStyle = (XSSFCellStyle)book.CreateCellStyle();
        //    XSSFFont font = (XSSFFont)book.CreateFont();
        //    font.FontHeight = 12;//设置字体大小
        //    font.FontName = "黑体";//设置字体为黑体
        //    cellStyle.SetFont(font);
        //    for (var i = 0; i < 18; i++)
        //    {
        //        row1.Cells[i].CellStyle = cellStyle;
        //    }
        //    //将数据逐步写入sheet1各个行  
        //    for (int i = 0; i < registrationExport.Count; i++)
        //    {
        //        NPOI.SS.UserModel.IRow rowtemp = sheet1.CreateRow(i + 2);
        //        rowtemp.CreateCell(0).SetCellValue(registrationExport[i].ApprovalNumber.NullToString());
        //        rowtemp.CreateCell(1).SetCellValue(registrationExport[i].ProductName.NullToString());
        //        rowtemp.CreateCell(2).SetCellValue(registrationExport[i].ProductNameRawData.NullToString());
        //        rowtemp.CreateCell(3).SetCellValue(registrationExport[i].BrandName.NullToString());
        //        rowtemp.CreateCell(4).SetCellValue(registrationExport[i].BrandNameRawData.NullToString());
        //        rowtemp.CreateCell(5).SetCellValue(registrationExport[i].Registrant.NullToString());
        //        rowtemp.CreateCell(6).SetCellValue(registrationExport[i].RegistrantRawData.NullToString());
        //        rowtemp.CreateCell(7).SetCellValue(registrationExport[i].Origin.NullToString());
        //        rowtemp.CreateCell(8).SetCellValue(registrationExport[i].Formulation.NullToString());
        //        rowtemp.CreateCell(9).SetCellValue(registrationExport[i].FormulationRawData.NullToString());
        //        rowtemp.CreateCell(10).SetCellValue(registrationExport[i].Specification.NullToString());
        //        rowtemp.CreateCell(11).SetCellValue(registrationExport[i].ManufacturerRawData.NullToString());
        //        rowtemp.CreateCell(12).SetCellValue(registrationExport[i].RepackagingCompanyRawData.NullToString());
        //        rowtemp.CreateCell(13).SetCellValue(registrationExport[i].ApprovalDate.ToUiDateString());
        //        rowtemp.CreateCell(14).SetCellValue(registrationExport[i].ExpirationDate.ToUiDateString());
        //        rowtemp.CreateCell(15).SetCellValue(registrationExport[i].Validity.NullToString());
        //        rowtemp.CreateCell(16).SetCellValue(registrationExport[i].DrugType.NullToString());
        //        rowtemp.CreateCell(17).SetCellValue(registrationExport[i].Package.NullToString());
        //        //....N行  
        //    }
        //    // 写入到客户端   
        //    DateTime dt = DateTime.Now;
        //    string dateTime = dt.ToString("yyMMddHHmmssfff");
        //    string fileName = "Registration list page" + userId + "_" + dateTime + ".xlsx";
        //    FileStream fs = new FileStream(string.Format(@"{0}\RegistrationExport\{1}", AppConstants.ExportPath, fileName), FileMode.Create);
        //    book.Write(fs);
        //    AppUtility.InsertUserExportCount(userId, exportCount);
        //    return File(string.Format(@"{0}\RegistrationExport\{1}", AppConstants.ExportPath, fileName), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        //}
    }
}
