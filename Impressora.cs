public class Impressora{

	public static void ImprimirExcel(Application app){
		app.Visible = false;
		app.DisplayAlerts = false;

		Excel.Workbook wb = app.Workbooks.Open(@"C:/Convertidas/Convertidas28.04.2016/Londrina/4502148837_001 - OK",Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);

		Exce4.Worksheet ws = (Excel.Worksheet)wb.Worksheet[1];

		ws.PrintOut(Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing,Type.Missing);

		//Limpar memória
		GC.Collect();
		GC.WaitForPendingFinalizers();

		Marshal.FinalReleaseComObject(ws);

		wb.Close(false,Type.Missing,Type.Missing);
		Marshal.FinalReleaseComObject(wb);

		app.Quit();
		Marshal.FinalReleaseComObject(app);
	}

	private void ImprimirArquivo(){
		this.Range["A1", missing].Value2 = "123";
		this.PrintOut(1,2,1,false,missing,true, false, missing);
	}

	private void ImprimirProcesso(){
		Process pr = new Process();
		pr.StartInfo.FileName = "arquivo.xlsx";
		pr.StartInfo.CreateNoWindow = true;
		pr.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
		pr.StartInfo.Verb = "Print";
		pr.Start();
		pr.WaitForExit();
		pr.Dispose();
	}	
}

