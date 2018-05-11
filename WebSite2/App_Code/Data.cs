using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;

/// <summary>
/// Descripción breve de Data
/// </summary>
public class Data
{
	public Data()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

     string cadenaCon;
        

        public OleDbConnection GetConnection ()
        {
            /* C:\Users\sala305\Documents\WebSite2\WebSite2\App_Data  */
            cadenaCon = @"Provider = Microsoft.Jet.OleDb.4.0; data source = C:\Users\PruebasCCO\Desktop\TallerPCSW\WebSite2\App_Data\tallercapas1.mdb";
            OleDbConnection cn = new OleDbConnection(cadenaCon);
        

        try
            {
                cn.Open ();
                return (cn);
            }
        catch (Exception)
            {
                return null;
            }
        }
}