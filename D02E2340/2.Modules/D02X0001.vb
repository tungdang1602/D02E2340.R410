''' <summary>
''' Module này liên qua đến các khai báo biến, enum, ... toàn cục
''' </summary>
''' <remarks>Các khai báo ở đây không được trùng với các khai báo ở các Module D99Xxxxx</remarks>
Module D02X0001

    ''' <summary>
    ''' Module đang coding D02E2340
    ''' </summary>
    Public Const MODULED02 As String = "D02E2340"
    ''' <summary>
    ''' Chuỗi D02
    ''' </summary>
    Public Const D02 As String = "D02"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_APP_NAME As String = "Lemon3"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_SECTION As String = "HandshakeR360"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_MODULE As String = "D02"
    ''' <summary>
    ''' Dùng cho kiểm tra Security theo chuẩn của DIGINET
    ''' </summary>
    Public Const L3_HS_VALUE As String = "R3.60.00.Y2007"
    ''' <summary>
    ''' Dùng cho kiểm tra lưu thành công hay không
    ''' </summary>
    Public gbSavedOK As Boolean = False
    Public gbEnabledMenuFind As Boolean = False

    ''' <summary>
    ''' Khai báo structure cho phần định dạng format
    ''' </summary>
    'Public Structure StructureFormat

    '    ''' <summary>
    '    ''' format thành tiền
    '    ''' </summary>
    '    Public OriginalAmount As String
    '    ''' <summary>
    '    ''' Số làm tròn của thành tiền
    '    ''' </summary>
    '    Public OriginalAmountRound As Integer
    '    ''' <summary>
    '    ''' format thành tiền quy đổi
    '    ''' </summary>
    '    Public ConvertedAmount As String
    '    ''' <summary>
    '    ''' Số làm tròn của thành tiền quy đổi
    '    ''' </summary>
    '    Public ConvertedAmountRound As Integer
    '    ''' <summary>
    '    ''' format tỷ giá
    '    ''' </summary>
    '    Public ExchangeRate As String
    '    ''' <summary>
    '    ''' Số làm tròn của tỷ giá
    '    ''' </summary>
    '    Public ExchangeRateRound As Integer
    '    ''' <summary>
    '    ''' Nguyên tệ gốc
    '    ''' </summary>
    '    Public BaseCurrencyID As String
    '    ''' <summary>
    '    ''' Dấu phân cách thập phân
    '    ''' </summary>
    '    Public DecimalSeperator As String
    '    ''' <summary>
    '    ''' Dấu phân cách hàng ngàn
    '    ''' </summary>
    '    Public ThousandSeperator As String
    '    Public DefaultNumber2 As String
    '    Public DefaultNumber4 As String
    '    Public Percentage As String
    '    '------------------------------------------------------------------------
    '    '  D91 Format here
    '    '------------------------------------------------------------------------
    'End Structure

    ''' <summary>
    ''' Khai bao de chon cac button tren luoi vd: Khoan muc, doi tuong,mat hang...
    ''' </summary>
    ''' <remarks></remarks>
    Public Enum Button
        AssetAccount = 0
        DepAccount = 1
    End Enum

    'Public D02Format As StructureFormat
    ''' <summary>
    ''' Lưu trữ các thiết lập tùy chọn
    ''' </summary>
    'Public D02Options As StructureOption

    ''' <summary>
    ''' Khai báo Structure cho phần Tùy chọn của Module
    ''' </summary>
    'Public Structure StructureOption
    '    ''' <summary>
    '    ''' Hỏi trước khi lưu
    '    ''' </summary>
    '    Public MessageAskBeforeSave As Boolean
    '    ''' <summary>
    '    ''' Thông báo khi lưu thành công
    '    ''' </summary>
    '    Public MessageWhenSaveOK As Boolean
    '    ''' <summary>
    '    ''' Hiển thị form chọn kỳ kế toán khi chạy chương trình
    '    ''' </summary>
    '    Public ViewFormPeriodWhenAppRun As Boolean
    '    ''' <summary>
    '    ''' Lưu giá trị gần nhất
    '    ''' </summary>
    '    Public SaveLastRecent As Boolean
    '    ''' <summary>
    '    ''' Lưu đơn vị mặc định
    '    ''' </summary>
    '    Public DefaultDivisionID As String
    '    ''' <summary>
    '    ''' Khóa thành tiền quy đổi
    '    ''' </summary>
    '    Public LockConvertedAmount As Boolean
    '    ''' <summary>
    '    ''' Làm tròn thành tiền quy đổi
    '    ''' </summary>
    '    Public RoundConvertedAmount As Boolean
    '    ''' <summary>
    '    ''' Hiển thị quy trình sơ đồ nghiệp vụ
    '    ''' </summary>
    '    Public ViewWorkflow As Boolean
    '    ''' <summary>
    '    ''' Ngôn ngữ báo cáo
    '    ''' </summary>
    '    Public ReportLanguage As Byte

    '    Public ShowReportPath As Boolean
    '    '------------------------------------------------------------------------
    '    '  D02 Options here
    '    '------------------------------------------------------------------------
    'End Structure

    ''' <summary>
    ''' Khai báo cho phần định dạng chung lấy từ D91P9300
    ''' Createdate 20/12/2007
    ''' </summary>
    ''' <remarks></remarks>
    'Public Structure StructureFormatNew
    '    ''' <summary>
    '    ''' Format tỷ giá
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public ExchangeRate As String
    '    ''' <summary>
    '    ''' Format nguyên tệ 
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public DecimalPlaces As String
    '    ''' <summary>
    '    ''' Format nguyên tệ ứng với mỗi loại tiền
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public MyOriginal As String
    '    ''' <summary>
    '    ''' Format tiền quy đổi
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public D90_Converted As String
    '    ''' <summary>
    '    ''' Format số lượng, số lượng quy đổi theo nhóm sản xuất
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public D07_Quantity As String
    '    ''' <summary>
    '    ''' Format đơn giá theo nhóm sản xuất
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public D07_UnitCost As String
    '    Public D08_Quantity As String
    '    Public D08_UnitCost As String
    '    Public D08_Ratio As String
    '    Public DecimalSeparator As String
    '    Public ThousandSeparator As String
    '    Public D90_ConvertedDecimals As Integer
    '    Public BaseCurrencyID As String 'Loai tien hoach toan
    '    ''' <summary>
    '    ''' Format 2 số lẽ
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public DefaultNumber2 As String
    '    ''' <summary>
    '    ''' Format 4 số lẽ
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public DefaultNumber4 As String
    '    ''' <summary>
    '    ''' Format 0 số lẽ
    '    ''' </summary>
    '    ''' <remarks></remarks>
    '    Public DefaultNumber0 As String
    'End Structure

    'Public D02Format As StructureFormatNew

    'Quyền Sửa số phiếu
    'Public giPerF5558 As Integer

    ''' <summary>
    ''' Dung de luu các trạng thai cua AuditLog
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PathReport9 As String = "\XReports\"
    ''' <summary>
    ''' Dùng cho form Chọn đường dẫn báo cáo: Custom Report
    ''' </summary>
    ''' <remarks></remarks>
    Public Const PathCustomizedReport9 As String = "\XCustom\"
    ''' <summary>
    '''  Dùng cho form Chọn đường dẫn báo cáo
    ''' </summary>
    ''' <remarks></remarks>
    Public gsReportPath As String

End Module
