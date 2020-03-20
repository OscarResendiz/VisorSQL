using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace Visor_sql_2015
{
    public class Generador_Excel  
    {
        string Title;
        int Records;
        StreamWriter w;
        FileStream fs;
        public static int Formato_Blanco = 0;
        public static int Formato_Azul = 1;
        public static int Formato_AzulClaro = 2;
        public static int Formato_Verde = 3;
        public static int Formato_Cafe = 4;
        public static int Formato_Naranja = 5;
        public static int Formato_Violeta = 6;
        public static int Formato_Rojo = 7;
        public static int Formato_Error = 7;


        public Generador_Excel(string Titulo, int Registros)
        {
            Title = Titulo;
            Records = Registros;
        }
    

        public void Inicia_Excel(string ruta)
        {

            fs = new FileStream(ruta, FileMode.Create, FileAccess.ReadWrite);
            w = new StreamWriter(fs);    
            EscribeCabecera();
        }
                  

        public void Termina_Excel()
        {
            EscribePiePagina();                             
            w.Close(); 
        }  

        public void EscribeCabecera()
        {
            StringBuilder html = new StringBuilder(); 
            html.Append("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.0 Transitional//EN\">");
            html.Append("<html>");
            html.Append("  <head>");
            html.Append("<title>Reporte_Viabilidad</title>");
            html.Append("<meta http-equiv=\"Content-Type\"content=\"text/html; charset=UTF-8\" />");
            html.Append("  </head>");
            html.Append("<body>");
            html.Append("<p>");
            html.Append("<table>");
            html.Append("<tr style=\"font-weight:bold;font-size: 16px;color: white;\">");
            html.Append("<td bgcolor=\"Blue\">"+ Title+"</td>");
            html.Append("<td bgcolor=\"Blue\">Registros: "+ Records.ToString()+"</td>");
            html.Append("</tr>");
            w.Write(html.ToString());
        }

        public void EscribeLinea( List<string> Arreglo_Renglon, bool EsTitulo, int Formato)
        {   
            string bgColor = "", fontColor = "";
            if (EsTitulo)
            {
                bgColor = " bgcolor=\"Black\" ";
                fontColor = " style=\"font-weight:bold;font-size: 14px;color: white;\" ";
            }
            else
            {
                switch (Formato)
                {
                    case 0:
                        bgColor = " bgcolor=\"White\" ";
                        fontColor = " style=\"font-size: 12px;color: darkblue;\" ";
                        break;
                    case 1:
                        bgColor = " bgcolor=\"Blue\" ";
                        fontColor = " style=\"font-size: 12px;color: white;\" ";
                        break;
                    case 2:
                        bgColor = " bgcolor=\"LightBlue\" ";
                        fontColor = " style=\"font-size: 12px;color: black;\" ";
                        break;
                    case 3:
                        bgColor = " bgcolor=\"Green\" ";
                        fontColor = " style=\"font-size: 12px;color: white;\" ";
                        break;
                    case 4:
                        bgColor = " bgcolor=\"Brown\" ";
                        fontColor = " style=\"font-size: 12px;color: white;\" ";
                        break;
                    case 5:
                        bgColor = " bgcolor=\"Orange\" ";
                        fontColor = " style=\"font-size: 12px;color: darkblue;\" ";
                        break;
                    case 6:
                        bgColor = " bgcolor=\"Violet\" ";
                        fontColor = " style=\"font-size: 12px;color: darkblue;\" ";
                        break;
                    case 7:
                        bgColor = " bgcolor=\"Red\" ";
                        fontColor = " style=\"font-weight:bold;font-size: 12px;color: white;\" ";
                        break;
                    default:
                        bgColor = " bgcolor=\"Blue\" ";
                        fontColor = " style=\"font-size: 12px;color: white;\" ";
                        break;
                }
            }
            w.Write(@"<tr>");
            for (int i = 0; i < Arreglo_Renglon.Count; i++)
            {
                w.Write(@"<td {1} {2}>{0}</td>", Arreglo_Renglon[i], bgColor, fontColor);
            }
            w.Write(@"</tr>");
        }

        public void EscribePiePagina()
        {
            StringBuilder html = new StringBuilder();       
            html.Append("  </table>");
            html.Append("</p>");
            html.Append(" </body>");
            html.Append("</html>");
            w.Write(html.ToString());
        }

    } 
}
