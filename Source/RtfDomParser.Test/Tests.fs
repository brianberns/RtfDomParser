namespace RtfDomParser.Test

open RtfDomParser
open Microsoft.VisualStudio.TestTools.UnitTesting

[<TestClass>]
type TestClass () =

    // Avoid error: "No data is available for encoding 1252".
    [<TestMethod>]
    member _.Encoding1252() =
        let rtf = "{\\rtf1\\ansi\\ansicpg1252\\deff0\\deflang1033{\\fonttbl{\\f0\\fnil Consolas;}{\\f1\\fnil\\fcharset0 Calibri;}}{\\colortbl ;\\red163\\green21\\blue21;}{\\*\\generator Msftedit 5.41.21.2510;}\\viewkind4\\uc1\\pard\\sa200\\sl276\\slmult1\\cf1\\lang9\\f0\\fs19 This is some text.\\cf0\\f1\\fs22\\par}"
        let doc = RTFDomDocument()
        doc.LoadRTFText(rtf);
        Assert.AreEqual<string>("This is some text.", doc.InnerText.Trim());
