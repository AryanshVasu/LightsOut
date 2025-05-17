using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    public static void WriteData(int[] data){
        File.Delete("data.txt");
        StreamWriter sw = new StreamWriter("data.txt");
        foreach (int num in data){
            sw.WriteLine(num.ToString());
        }
        sw.Flush();
        sw.Close();
    }

    public static int[] ReadData(){
        StreamReader sr=new StreamReader("data.txt");
        int[] data=new int[6];
        for (int i=0;i<6;i++){
            data[i]=int.Parse(sr.ReadLine());
        }
        return data;
    }
}
