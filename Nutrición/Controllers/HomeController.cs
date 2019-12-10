using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Nutrición.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }



        /*[HttpPost]
        public ContentResult AjaxMethod(string paciente)
        {
            string query = "select Replace(Ficha_Nutricion1.kg_musc_ing, ',', '.'), Replace(Ficha_Nutricion1.kg_grasa_ing, ',', '.'), Replace(Ficha_Nutricion1.porc_mg_ing, ',', '.'), Replace(Ficha_Nutricion1.nivel_gv_ing, ',', '.'), Replace(Ficha_Nutricion1.indice_ing, ',', '.'), Replace(Ficha_Nutricion1.p_cintura_ing, ',', '.'), Replace(Ficha_Nutricion1.peso_ing, ',', '.'), Replace(Ficha_Nutricion1.talla_ing, ',', '.'), Replace(Ficha_Nutricion1.imc_ing, ',', '.'), Replace(Ficha_Nutricion1.kg_musc_egr, ',', '.'), Replace(Ficha_Nutricion1.kg_grasa_egr, ',', '.'), Replace(Ficha_Nutricion1.porc_mg_egr, ',', '.'), Replace(Ficha_Nutricion1.nivel_gv_egr, ',', '.'), Replace(Ficha_Nutricion1.indice_egr, ',', '.'), Replace(Ficha_Nutricion1.p_cintura_egr, ',', '.'), Replace(Ficha_Nutricion1.peso_egr, ',', '.'), Replace(Ficha_Nutricion1.talla_egr, ',', '.'), Replace(Ficha_Nutricion1.imc_egr, ',', '.'), COUNT(Ficha_Nutricion1.id_ficha_nutri)";
            query += "FROM Ficha INNER JOIN  Ficha_Nutricion1 ON Ficha_Nutricion1.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @Idpaciente GROUP BY Ficha_Nutricion1.kg_musc_ing, Ficha_Nutricion1.kg_grasa_ing, Ficha_Nutricion1.porc_mg_ing, Ficha_Nutricion1.nivel_gv_ing, Ficha_Nutricion1.indice_ing, Ficha_Nutricion1.p_cintura_ing, Ficha_Nutricion1.peso_ing, Ficha_Nutricion1.talla_ing, Ficha_Nutricion1.imc_ing, Ficha_Nutricion1.kg_musc_egr, Ficha_Nutricion1.kg_grasa_egr, Ficha_Nutricion1.porc_mg_egr, Ficha_Nutricion1.nivel_gv_egr, Ficha_Nutricion1.indice_egr, Ficha_Nutricion1.p_cintura_egr, Ficha_Nutricion1.peso_egr, Ficha_Nutricion1.talla_egr, Ficha_Nutricion1.imc_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Idpaciente", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1},value2:{2},value3:{3},value4:{4},value5:{5},value6:{6},value7:{7},value8:{8},value9:{9},value10:{10},value11:{11},value12:{12},value13:{13},value14:{14},value15:{15},value16:{16},value17:{17}", sdr[0], sdr[1], sdr[2], sdr[3], sdr[4], sdr[5], sdr[6], sdr[7], sdr[8], sdr[9], sdr[10], sdr[11], sdr[12], sdr[13], sdr[14], sdr[15], sdr[15], sdr[16], sdr[17]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");
                        
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }*/












        [HttpPost]
        public ContentResult AjaxMethod1(string paciente)
        {
            string query = "select Replace(Ficha_Nutricion.kg_musc_ing, ',', '.'), Replace(Ficha_Nutricion.kg_grasa_ing, ',', '.'), Replace(Ficha_Nutricion.kg_musc_egr, ',', '.'), Replace(Ficha_Nutricion.kg_grasa_egr, ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri)";
            query += "FROM Ficha INNER JOIN  Ficha_Nutricion ON Ficha_Nutricion.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @Idpaciente GROUP BY Ficha_Nutricion.kg_musc_ing, Ficha_Nutricion.kg_grasa_ing, Ficha_Nutricion.kg_musc_egr, Ficha_Nutricion.kg_grasa_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Idpaciente", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1},value2:{2},value3:{3}", sdr[0], sdr[1], sdr[2], sdr[3]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");

                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }







        [HttpPost]
        public ContentResult AjaxMethod2(string paciente)
        {
            string query = "select Replace(Ficha_Nutricion.porc_mg_ing, ',', '.'), Replace(Ficha_Nutricion.porc_mg_egr, ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri)";
            query += "FROM Ficha INNER JOIN  Ficha_Nutricion ON Ficha_Nutricion.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @Idpaciente GROUP BY Ficha_Nutricion.porc_mg_ing, Ficha_Nutricion.porc_mg_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Idpaciente", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");

                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }



        [HttpPost]
        public ContentResult AjaxMethod3(string paciente)
        {
            string query = "select Replace(Ficha_Nutricion.nivel_gv_ing, ',', '.'), Replace(Ficha_Nutricion.nivel_gv_egr, ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri)";
            query += "FROM Ficha INNER JOIN  Ficha_Nutricion ON Ficha_Nutricion.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @Idpaciente GROUP BY Ficha_Nutricion.nivel_gv_ing, Ficha_Nutricion.nivel_gv_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Idpaciente", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");

                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }


        [HttpPost]
        public ContentResult AjaxMethod4(string paciente)
        {
            string query = "select Replace(Ficha_Nutricion.indice_ing, ',', '.'), Replace(Ficha_Nutricion.indice_egr, ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri)";
            query += "FROM Ficha INNER JOIN  Ficha_Nutricion ON Ficha_Nutricion.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @Idpaciente GROUP BY Ficha_Nutricion.indice_ing, Ficha_Nutricion.indice_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Idpaciente", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");

                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }


        [HttpPost]
        public ContentResult AjaxMethod5(string paciente)
        {
            string query = "select Replace(Ficha_Nutricion.p_cintura_ing, ',', '.'), Replace(Ficha_Nutricion.p_cintura_egr, ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri)";
            query += "FROM Ficha INNER JOIN  Ficha_Nutricion ON Ficha_Nutricion.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @Idpaciente GROUP BY Ficha_Nutricion.p_cintura_ing, Ficha_Nutricion.p_cintura_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Idpaciente", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");

                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }


        [HttpPost]
        public ContentResult AjaxMethod6(string paciente)
        {
            string query = "select Replace(Ficha_Nutricion.peso_ing, ',', '.'), Replace(Ficha_Nutricion.peso_egr, ',', '.'), Replace(Ficha_Nutricion.talla_ing, ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri)";
            query += "FROM Ficha INNER JOIN  Ficha_Nutricion ON Ficha_Nutricion.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @Idpaciente GROUP BY Ficha_Nutricion.peso_ing, Ficha_Nutricion.peso_egr, Ficha_Nutricion.talla_ing";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Idpaciente", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}, value2:{2}", sdr[0], sdr[1], sdr[2]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");

                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }


        [HttpPost]
        public ContentResult AjaxMethod7(string paciente)
        {
            string query = "select Replace(Ficha_Nutricion.talla_ing, ',', '.'), Replace(Ficha_Nutricion.talla_egr, ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri)";
            query += "FROM Ficha INNER JOIN  Ficha_Nutricion ON Ficha_Nutricion.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @Idpaciente GROUP BY Ficha_Nutricion.talla_ing, Ficha_Nutricion.talla_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Idpaciente", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");

                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }



        [HttpPost]
        public ContentResult AjaxMethod8(string paciente)
        {
            string query = "select Replace(Ficha_Nutricion.imc_ing, ',', '.'), Replace(Ficha_Nutricion.imc_egr, ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri)";
            query += "FROM Ficha INNER JOIN  Ficha_Nutricion ON Ficha_Nutricion.id_ficha=Ficha.id_ficha inner join Paciente on Paciente.id_paciente = Ficha.id_paciente where Paciente.id_paciente = @Idpaciente GROUP BY Ficha_Nutricion.imc_ing, Ficha_Nutricion.imc_egr";
            //string query = "select K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr, COUNT(K.id_ficha_kine)";
            //query += "FROM Ficha_Kinesiologia K, Ficha F, Paciente Pa Where K.id_ficha = F.id_ficha And F.id_paciente ='" + paciente + "'group by K.ergo_vol_ing, K.ergo_voml_ing, K.ergo_fcmax_ing, K.ergo_vol_egr, K.ergo_voml_egr, K.ergo_fcmax_egr";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    cmd.Parameters.AddWithValue("@Idpaciente", paciente);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");

                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }

























        /*[HttpPost]
        public ContentResult AjaxMethodPro(string genero, string control, string morbidos, string fecha)
        {
            //string query = "select AVG(Ficha_Kinesiologia.ergo_vol_ing), AVG(Ficha_Kinesiologia.ergo_voml_ing), AVG(Ficha_Kinesiologia.ergo_vol_egr), AVG(Ficha_Kinesiologia.ergo_voml_egr)";
            //query += "FROM Ficha INNER JOIN Ficha_Kinesiologia On Ficha_Kinesiologia.id_ficha=Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Ficha_Kinesiologia.riesgo = @Riesgo And Persona.sexo = @Genero and Ficha_Kinesiologia.ergo_fecha_egr = @Fecha group by Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing, Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing";

            string query = "select Replace(AVG(Ficha_Nutricion1.kg_musc_ing), ',', '.'), Replace(AVG(Ficha_Nutricion1.kg_grasa_ing), ',', '.'), Replace(AVG(Ficha_Nutricion1.porc_mg_ing), ',', '.'), Replace(AVG(Ficha_Nutricion1.nivel_gv_ing), ',', '.'), Replace(AVG(Ficha_Nutricion1.indice_ing), ',', '.'), Replace(AVG(Ficha_Nutricion1.p_cintura_ing), ',', '.'), Replace(AVG(Ficha_Nutricion1.peso_ing), ',', '.'), Replace(AVG(Ficha_Nutricion1.talla_ing), ',', '.'), Replace(AVG(Ficha_Nutricion1.imc_ing), ',', '.'), Replace(AVG(Ficha_Nutricion1.kg_musc_egr), ',', '.'), Replace(AVG(Ficha_Nutricion1.kg_grasa_egr), ',', '.'), Replace(AVG(Ficha_Nutricion1.porc_mg_egr), ',', '.'), Replace(AVG(Ficha_Nutricion1.nivel_gv_egr), ',', '.'), Replace(AVG(Ficha_Nutricion1.indice_egr), ',', '.'), Replace(AVG(Ficha_Nutricion1.p_cintura_egr), ',', '.'), Replace(AVG(Ficha_Nutricion1.peso_egr), ',', '.'), Replace(AVG(Ficha_Nutricion1.talla_egr), ',', '.'), Replace(AVG(Ficha_Nutricion1.imc_egr), ',', '.'), COUNT(Ficha_Nutricion1.id_ficha_nutri) From Ficha INNER JOIN Ficha_Nutricion1 On Ficha_Nutricion1.id_ficha = Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Persona.sexo = @Genero And Ficha_Nutricion1.n_contr_nutr = @Control And Ficha_Nutricion1.morbidos = @Morbidos And fecha_eval_ing BETWEEN @Fecha And GETDATE()";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Control", control);
                    cmd.Parameters.AddWithValue("@Morbidos", morbidos);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1},value2:{2},value3:{3},value4:{4},value5:{5},value6:{6},value7:{7},value8:{8},value9:{9},value10:{10},value11:{11},value12:{12},value13:{13},value14:{14},value15:{15},value16:{16},value17:{17},value18:{18}", sdr[0], sdr[1], sdr[2], sdr[3], sdr[4], sdr[5], sdr[6], sdr[7], sdr[8], sdr[9], sdr[10], sdr[11], sdr[12], sdr[13], sdr[14], sdr[15], sdr[16], sdr[17], sdr[18]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }*/





        [HttpPost]
        public ContentResult AjaxMethodPro1(string genero, string control, string morbidos, string fecha)
        {
            //string query = "select AVG(Ficha_Kinesiologia.ergo_vol_ing), AVG(Ficha_Kinesiologia.ergo_voml_ing), AVG(Ficha_Kinesiologia.ergo_vol_egr), AVG(Ficha_Kinesiologia.ergo_voml_egr)";
            //query += "FROM Ficha INNER JOIN Ficha_Kinesiologia On Ficha_Kinesiologia.id_ficha=Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Ficha_Kinesiologia.riesgo = @Riesgo And Persona.sexo = @Genero and Ficha_Kinesiologia.ergo_fecha_egr = @Fecha group by Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing, Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing";

            string query = "select Replace(AVG(Ficha_Nutricion.kg_musc_ing), ',', '.'), Replace(AVG(Ficha_Nutricion.kg_grasa_ing), ',', '.'), Replace(AVG(Ficha_Nutricion.kg_musc_egr), ',', '.'), Replace(AVG(Ficha_Nutricion.kg_grasa_egr), ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri) From Ficha INNER JOIN Ficha_Nutricion On Ficha_Nutricion.id_ficha = Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Persona.sexo = @Genero And Ficha_Nutricion.n_contr_nutr = @Control And Ficha_Nutricion.morbidos = @Morbidos And fecha_eval_ing BETWEEN @Fecha And GETDATE()";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Control", control);
                    cmd.Parameters.AddWithValue("@Morbidos", morbidos);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1},value2:{2},value3:{3},value4:{4}", sdr[0], sdr[1], sdr[2], sdr[3], sdr[4]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }




        [HttpPost]
        public ContentResult AjaxMethodPro2(string genero, string control, string morbidos, string fecha)
        {
            //string query = "select AVG(Ficha_Kinesiologia.ergo_vol_ing), AVG(Ficha_Kinesiologia.ergo_voml_ing), AVG(Ficha_Kinesiologia.ergo_vol_egr), AVG(Ficha_Kinesiologia.ergo_voml_egr)";
            //query += "FROM Ficha INNER JOIN Ficha_Kinesiologia On Ficha_Kinesiologia.id_ficha=Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Ficha_Kinesiologia.riesgo = @Riesgo And Persona.sexo = @Genero and Ficha_Kinesiologia.ergo_fecha_egr = @Fecha group by Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing, Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing";

            string query = "select Replace(AVG(Ficha_Nutricion.porc_mg_ing), ',', '.'), Replace(AVG(Ficha_Nutricion.porc_mg_egr), ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri) From Ficha INNER JOIN Ficha_Nutricion On Ficha_Nutricion.id_ficha = Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Persona.sexo = @Genero And Ficha_Nutricion.n_contr_nutr = @Control And Ficha_Nutricion.morbidos = @Morbidos And fecha_eval_ing BETWEEN @Fecha And GETDATE()";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Control", control);
                    cmd.Parameters.AddWithValue("@Morbidos", morbidos);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }




        [HttpPost]
        public ContentResult AjaxMethodPro3(string genero, string control, string morbidos, string fecha)
        {
            //string query = "select AVG(Ficha_Kinesiologia.ergo_vol_ing), AVG(Ficha_Kinesiologia.ergo_voml_ing), AVG(Ficha_Kinesiologia.ergo_vol_egr), AVG(Ficha_Kinesiologia.ergo_voml_egr)";
            //query += "FROM Ficha INNER JOIN Ficha_Kinesiologia On Ficha_Kinesiologia.id_ficha=Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Ficha_Kinesiologia.riesgo = @Riesgo And Persona.sexo = @Genero and Ficha_Kinesiologia.ergo_fecha_egr = @Fecha group by Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing, Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing";

            string query = "select Replace(AVG(Ficha_Nutricion.nivel_gv_ing), ',', '.'), Replace(AVG(Ficha_Nutricion.nivel_gv_egr), ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri) From Ficha INNER JOIN Ficha_Nutricion On Ficha_Nutricion.id_ficha = Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Persona.sexo = @Genero And Ficha_Nutricion.n_contr_nutr = @Control And Ficha_Nutricion.morbidos = @Morbidos And fecha_eval_ing BETWEEN @Fecha And GETDATE()";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Control", control);
                    cmd.Parameters.AddWithValue("@Morbidos", morbidos);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }




        [HttpPost]
        public ContentResult AjaxMethodPro4(string genero, string control, string morbidos, string fecha)
        {
            //string query = "select AVG(Ficha_Kinesiologia.ergo_vol_ing), AVG(Ficha_Kinesiologia.ergo_voml_ing), AVG(Ficha_Kinesiologia.ergo_vol_egr), AVG(Ficha_Kinesiologia.ergo_voml_egr)";
            //query += "FROM Ficha INNER JOIN Ficha_Kinesiologia On Ficha_Kinesiologia.id_ficha=Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Ficha_Kinesiologia.riesgo = @Riesgo And Persona.sexo = @Genero and Ficha_Kinesiologia.ergo_fecha_egr = @Fecha group by Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing, Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing";

            string query = "select Replace(AVG(Ficha_Nutricion.indice_ing), ',', '.'), Replace(AVG(Ficha_Nutricion.indice_egr), ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri) From Ficha INNER JOIN Ficha_Nutricion On Ficha_Nutricion.id_ficha = Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Persona.sexo = @Genero And Ficha_Nutricion.n_contr_nutr = @Control And Ficha_Nutricion.morbidos = @Morbidos And fecha_eval_ing BETWEEN @Fecha And GETDATE()";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Control", control);
                    cmd.Parameters.AddWithValue("@Morbidos", morbidos);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }



        [HttpPost]
        public ContentResult AjaxMethodPro5(string genero, string control, string morbidos, string fecha)
        {
            //string query = "select AVG(Ficha_Kinesiologia.ergo_vol_ing), AVG(Ficha_Kinesiologia.ergo_voml_ing), AVG(Ficha_Kinesiologia.ergo_vol_egr), AVG(Ficha_Kinesiologia.ergo_voml_egr)";
            //query += "FROM Ficha INNER JOIN Ficha_Kinesiologia On Ficha_Kinesiologia.id_ficha=Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Ficha_Kinesiologia.riesgo = @Riesgo And Persona.sexo = @Genero and Ficha_Kinesiologia.ergo_fecha_egr = @Fecha group by Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing, Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing";

            string query = "select Replace(AVG(Ficha_Nutricion.p_cintura_ing), ',', '.'),Replace(AVG(Ficha_Nutricion.p_cintura_egr), ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri) From Ficha INNER JOIN Ficha_Nutricion On Ficha_Nutricion.id_ficha = Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Persona.sexo = @Genero And Ficha_Nutricion.n_contr_nutr = @Control And Ficha_Nutricion.morbidos = @Morbidos And fecha_eval_ing BETWEEN @Fecha And GETDATE()";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Control", control);
                    cmd.Parameters.AddWithValue("@Morbidos", morbidos);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }



        [HttpPost]
        public ContentResult AjaxMethodPro6(string genero, string control, string morbidos, string fecha)
        {
            //string query = "select AVG(Ficha_Kinesiologia.ergo_vol_ing), AVG(Ficha_Kinesiologia.ergo_voml_ing), AVG(Ficha_Kinesiologia.ergo_vol_egr), AVG(Ficha_Kinesiologia.ergo_voml_egr)";
            //query += "FROM Ficha INNER JOIN Ficha_Kinesiologia On Ficha_Kinesiologia.id_ficha=Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Ficha_Kinesiologia.riesgo = @Riesgo And Persona.sexo = @Genero and Ficha_Kinesiologia.ergo_fecha_egr = @Fecha group by Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing, Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing";

            string query = "select Replace(AVG(Ficha_Nutricion.peso_ing), ',', '.'),Replace(AVG(Ficha_Nutricion.peso_egr), ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri) From Ficha INNER JOIN Ficha_Nutricion On Ficha_Nutricion.id_ficha = Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Persona.sexo = @Genero And Ficha_Nutricion.n_contr_nutr = @Control And Ficha_Nutricion.morbidos = @Morbidos And fecha_eval_ing BETWEEN @Fecha And GETDATE()";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Control", control);
                    cmd.Parameters.AddWithValue("@Morbidos", morbidos);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }




        [HttpPost]
        public ContentResult AjaxMethodPro7(string genero, string control, string morbidos, string fecha)
        {
            //string query = "select AVG(Ficha_Kinesiologia.ergo_vol_ing), AVG(Ficha_Kinesiologia.ergo_voml_ing), AVG(Ficha_Kinesiologia.ergo_vol_egr), AVG(Ficha_Kinesiologia.ergo_voml_egr)";
            //query += "FROM Ficha INNER JOIN Ficha_Kinesiologia On Ficha_Kinesiologia.id_ficha=Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Ficha_Kinesiologia.riesgo = @Riesgo And Persona.sexo = @Genero and Ficha_Kinesiologia.ergo_fecha_egr = @Fecha group by Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing, Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing";

            string query = "select Replace(AVG(Ficha_Nutricion.talla_ing), ',', '.'),Replace(AVG(Ficha_Nutricion.talla_egr), ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri) From Ficha INNER JOIN Ficha_Nutricion On Ficha_Nutricion.id_ficha = Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Persona.sexo = @Genero And Ficha_Nutricion.n_contr_nutr = @Control And Ficha_Nutricion.morbidos = @Morbidos And fecha_eval_ing BETWEEN @Fecha And GETDATE()";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Control", control);
                    cmd.Parameters.AddWithValue("@Morbidos", morbidos);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }




        [HttpPost]
        public ContentResult AjaxMethodPro8(string genero, string control, string morbidos, string fecha)
        {
            //string query = "select AVG(Ficha_Kinesiologia.ergo_vol_ing), AVG(Ficha_Kinesiologia.ergo_voml_ing), AVG(Ficha_Kinesiologia.ergo_vol_egr), AVG(Ficha_Kinesiologia.ergo_voml_egr)";
            //query += "FROM Ficha INNER JOIN Ficha_Kinesiologia On Ficha_Kinesiologia.id_ficha=Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Ficha_Kinesiologia.riesgo = @Riesgo And Persona.sexo = @Genero and Ficha_Kinesiologia.ergo_fecha_egr = @Fecha group by Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing, Ficha_Kinesiologia.ergo_vol_ing, Ficha_Kinesiologia.ergo_voml_ing";

            string query = "select Replace(AVG(Ficha_Nutricion.imc_ing), ',', '.'),Replace(AVG(Ficha_Nutricion.imc_egr), ',', '.'), COUNT(Ficha_Nutricion.id_ficha_nutri) From Ficha INNER JOIN Ficha_Nutricion On Ficha_Nutricion.id_ficha = Ficha.id_ficha INNER JOIN Paciente on Paciente.id_paciente = Ficha.id_paciente INNER JOIN Persona on Persona.id_persona = Paciente.id_persona where Persona.sexo = @Genero And Ficha_Nutricion.n_contr_nutr = @Control And Ficha_Nutricion.morbidos = @Morbidos And fecha_eval_ing BETWEEN @Fecha And GETDATE()";

            string constr = ConfigurationManager.ConnectionStrings["ConexionKaplan"].ConnectionString;
            StringBuilder sb = new StringBuilder();
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;

                    cmd.Parameters.AddWithValue("@Genero", genero);
                    cmd.Parameters.AddWithValue("@Control", control);
                    cmd.Parameters.AddWithValue("@Morbidos", morbidos);
                    cmd.Parameters.AddWithValue("@Fecha", fecha);
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sb.Append("[");

                        while (sdr.Read())
                        {
                            sb.Append("{");
                            System.Threading.Thread.Sleep(50);
                            string color = String.Format("#{0:X6}", new Random().Next(0x1000000));
                            sb.Append(string.Format("value0:{0},value1:{1}", sdr[0], sdr[1]));
                            sb.Append("},");
                        }

                        sb = sb.Remove(sb.Length - 1, 1);
                        sb.Append("]");


                        //sb.Append("}");
                    }

                    con.Close();
                }
            }

            return Content(sb.ToString());
        }

    }
    

}