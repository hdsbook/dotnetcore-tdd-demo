## Adapter 模式：Exporter

Adapter 模式中有三個角色：Target, Adapter, Adaptee

---

Target: IExporter

Adapter: PDFExporter、ODSExporter

Adaptee: PDFDotnet、ODSManager

---

### 情境簡單說明

原本可能只有 ExcelExporter，但後來有多種格式匯出的需求

希望能用 Strategy 模式實作

但第三方套件 PDFDotnet、ODSManager 它們所實作的介面都不同

所以希望都能以 ExcelExporter 的介面為主一起工作

### 達到的效果

原本：

```C#
var excelExporter = new ExcelExporter();
var pdfPlugin = new PDFDotnet();
var odsPlugin = new ODSManager();

// 原本 PDF、ODS 各自實作不同的介面，呼叫的方法名稱不同
Assert.AreEqual("匯出EXCEL", excelExporter.Export());
Assert.AreEqual("匯出PDF", pdfPlugin.Save());
Assert.AreEqual("匯出ODS", odsPlugin.Output());

```

套用轉接器模式後：

```C#
var excelExporter = new ExcelExporter();
var pdfExporter = new PDFExporter();
var odsExporter = new ODSExporter();

// 採用 Adapter 轉接後，均使用相同的介面
Assert.AreEqual("匯出EXCEL", excelExporter.Export());
Assert.AreEqual("匯出PDF", pdfExporter.Export());
Assert.AreEqual("匯出ODS", odsExporter.Export());
```