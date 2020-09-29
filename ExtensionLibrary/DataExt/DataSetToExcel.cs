using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;

namespace ExtensionLibrary.DataExt
{
    public static class DataSetToExcel
    {
        private const uint _wordWrapCellStyleIdx = 1;


        /// <summary>
        /// Сформировать Excel на основе DataSet
        /// </summary>
        /// <param name="ds">DataSet с данными</param>
        /// <param name="tableName">Наименование листа Excel</param>
        /// <param name="columnsAlias">Сопоставление имен колонок в DataSet с названиями колонок в Excel</param>
        /// <returns></returns>
        public static byte[] ExportDataSetToBytes(this DataSet ds, string tableName, Dictionary<string, string> columnsAlias)
        {
            using (MemoryStream documentStream = new MemoryStream())
            {
                using (SpreadsheetDocument workbook = SpreadsheetDocument.Create(documentStream, SpreadsheetDocumentType.Workbook))
                {
                    WorkbookPart workbookPart = workbook.AddWorkbookPart();
                    workbook.WorkbookPart.Workbook = new Workbook
                    {
                        Sheets = new Sheets()
                    };

                    AddStyleSheet(workbook);

                    foreach (DataTable table in ds.Tables)
                    {
                        WorksheetPart sheetPart = workbook.WorkbookPart.AddNewPart<WorksheetPart>();
                        SheetData sheetData = new SheetData();
                        sheetPart.Worksheet = new Worksheet();

                        Sheets sheets = workbook.WorkbookPart.Workbook.GetFirstChild<Sheets>();
                        string relationshipId = workbook.WorkbookPart.GetIdOfPart(sheetPart);

                        uint sheetId = 1;
                        if (sheets.Elements<Sheet>().Count() > 0)
                        {
                            sheetId =
                                sheets.Elements<Sheet>().Select(s => s.SheetId.Value).Max() + 1;
                        }


                        Sheet sheet = new Sheet() { Id = relationshipId, SheetId = sheetId, Name = tableName };
                        sheets.Append(sheet);

                        var columnDefinitions = new Columns();
                        Row headerRow = new Row();

                        List<string> columns = BuildColumn(table, columnsAlias, columnDefinitions, headerRow);
                        sheetData.AppendChild(headerRow);
                        FillRow(table, sheetData, columnsAlias, columns);

                        sheetPart.Worksheet.Append(columnDefinitions);
                        sheetPart.Worksheet.Append(sheetData);
                    }
                    workbook.Save();
                    workbook.Close();
                }
                return documentStream.ToArray();
            }
        }


        /// <summary>
        /// Сформировать колонки
        /// </summary>
        private static List<string> BuildColumn(DataTable table, Dictionary<string, string> columnsAlias, Columns columnDefinitions, Row headerRow)
        {
            List<string> columns = new List<string>();
            for (int i = 0; i < table.Columns.Count; i++)
            {
                var colNumber = (uint)i + 1;
                var column = table.Columns[i];

                columnDefinitions.Append(new Column()
                {
                    Min = colNumber,
                    Max = colNumber,
                    Width = 30,
                    CustomWidth = true,
                });

                columns.Add(columnsAlias[column.ColumnName]);

                Cell cell = new Cell
                {
                    DataType = CellValues.String,
                    CellValue = new CellValue(columnsAlias[column.ColumnName])
                };
                headerRow.AppendChild(cell);
            }

            return columns;
        }


        /// <summary>
        /// Заполнение строк
        /// </summary>
        private static void FillRow(DataTable table, SheetData sheetData, Dictionary<string, string> columnsAlias, List<string> columns)
        {
            foreach (DataRow dsrow in table.Rows)
            {
                Row newRow = new Row();
                foreach (string col in columns)
                {
                    var columnKey = columnsAlias.FirstOrDefault(x => x.Value.Contains(col.ToString())).Key;
                    var val = dsrow[columnKey].ToString();

                    Cell cell = new Cell
                    {
                        DataType = CellValues.String,
                        CellValue = new CellValue(val == "  " || val == "" || val == null ? "-" : val),
                        StyleIndex = _wordWrapCellStyleIdx
                    };
                    newRow.AppendChild(cell);
                }

                sheetData.AppendChild(newRow);
            }
        }


        private static WorkbookStylesPart AddStyleSheet(SpreadsheetDocument spreadsheet)
        {
            WorkbookStylesPart stylesheet = spreadsheet.WorkbookPart.AddNewPart<WorkbookStylesPart>();
            Stylesheet workbookstylesheet = new Stylesheet();

            // <Fonts>
            Font font0 = new Font();            // Default font
            Fonts fonts = new Fonts();          // <APPENDING Fonts>
            fonts.Append(font0);

            // <Fills>
            Fill fill0 = new Fill();            // Default fill
            Fills fills = new Fills();          // <APPENDING Fills>
            fills.Append(fill0);

            // <Borders>
            Border border0 = new Border();      // Defualt border
            Borders borders = new Borders();    // <APPENDING Borders>
            borders.Append(border0);

            // <CellFormats>
            CellFormat cellformat0 = new CellFormat()   // Default style : Mandatory
            {
                FontId = 0,
                FillId = 0,
                BorderId = 0
            };

            // Style with textwrap set
            CellFormat cellformat1 = new CellFormat(new Alignment()
            {
                WrapText = true,
                Vertical = VerticalAlignmentValues.Top
            });



            // <APPENDING CellFormats>
            CellFormats cellformats = new CellFormats();
            cellformats.Append(cellformat0);
            cellformats.Append(cellformat1);

            // Append FONTS, FILLS , BORDERS & CellFormats to stylesheet <Preserve the ORDER>
            workbookstylesheet.Append(fonts);
            workbookstylesheet.Append(fills);
            workbookstylesheet.Append(borders);
            workbookstylesheet.Append(cellformats);

            // Finalize
            stylesheet.Stylesheet = workbookstylesheet;
            stylesheet.Stylesheet.Save();

            return stylesheet;
        }
    }
}
