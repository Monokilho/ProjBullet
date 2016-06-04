using UnityEngine;
using System.Collections;

using System.Linq;
using System; 


public class CSVParser {

	public double[][] parseFile(string csvFile){
		double[][] grid = seperateCsvFile (csvFile);
		return grid;
	}

	double[][] seperateCsvFile (string csvFile)
	{

		string[] lines =  csvFile.Split(new char[] {'\n'});
		int nlines = lines.Length;
		if (lines [nlines-1].Equals ("")) {
			string[] aux = new string[nlines-1];
			Array.Copy(lines,0,aux,0,nlines-1);
			lines=aux;
			nlines=nlines-1;
		}
			
		int ncolums = lines[0].Split(new char[] {','}).Length;
		int temp = lines[1].Split(new char[] {','}).Length;
		if (temp > ncolums)
			ncolums = temp;
		double[][] grid = new double[ncolums][];
		double parsedouble = 0;
		for (int x =0; x<ncolums; x++){			
			grid [x] = new double[nlines];
		}
		

		for (int y=0; y<nlines; y++) {
			string[] rows = lines[y].Split(new char[] {','});
			for (int x =0; x<rows.Count(); x++){
				if(!rows[x].Equals("")){
				if(double.TryParse(rows[x], out parsedouble))
					grid[x][y] = parsedouble;
				else{
					Debug.LogError("Failed at parsing CsvFile.");}
				}
			}
		}

		return grid;
	}


	//**  not working **//
	/*
	void debugOutputGrid (float[][] grid)
	{
		string debugline = "";
		for (int y=0; y<= grid.GetUpperBound(1); y++) {
			for(int x = 0; x<= grid.GetUpperBound(0);x++){

				debugline = string.Concat(debugline,grid[x][y].ToString());
				debugline = string.Concat(debugline," | ");
			}
			debugline = string.Concat(debugline,"\n");
		}
		Debug.Log(debugline);
	}*/
}
