using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

using Newtonsoft.Json;

using wa_colors.Models;

namespace wa_colors.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string next_page;
            string prev_page;
            List<viewData> listColors = new List<viewData>();
            
            getColors(1, out listColors, out next_page, out prev_page);

            ViewData["listColors"] = listColors.ToList();
            ViewBag.next_page = next_page;
            ViewBag.prev_page = prev_page;
            ViewBag.curr_page = 1;

            return View("Index");
        }

        public ActionResult setPage(int page)
        {
            string next_page;
            string prev_page;
            List<viewData> listColors = new List<viewData>();

            getColors(page, out listColors, out next_page, out prev_page);

            ViewData["listColors"] = listColors.ToList();
            ViewBag.next_page = next_page;
            ViewBag.prev_page = prev_page;
            ViewBag.curr_page = page;

            return View("Index");
        }

        // FUNCIONES
        private void getColors(int? page, out List<viewData> data_color, out string next_page, out string prev_page)
        {
            next_page = "";
            prev_page = "";

            string apiURL = "https://reqres.in/api/colors";
            List<viewData> result = new List<viewData>();

            string data_year, data_name, data_code, data_pant;

            if (page != 1 && page != null)
            {
                apiURL += "?page=" + page.ToString();
            }

            WebClient client = new WebClient();
            string response = client.DownloadString(apiURL);
            API listColors = JsonConvert.DeserializeObject<API>(response);

            for (var c = 0; c < listColors.data.Count(); c++)
            {
                // VALIDACIONES PARA EL TAG AÑO - YEAR
                if (listColors.data[c].year != "" || listColors.data[c].year != null)
                {
                    data_year = listColors.data[c].year.Trim().Replace(" ", "");
                }
                else if (listColors.data[c].año != "" || listColors.data[c].año != null)
                {
                    data_year = listColors.data[c].año.Trim().Replace(" ", "");
                }
                else
                {
                    data_year = "1900";
                }

                // VALIDACIONES PARA EL TAG NOMBRE - NAME
                if (listColors.data[c].name != "" || listColors.data[c].name != null)
                {
                    data_name = listColors.data[c].name.Trim().Replace(" ", "");
                }
                else if (listColors.data[c].nombre != "" || listColors.data[c].nombre != null)
                {
                    data_name = listColors.data[c].name.Trim().Replace(" ", "");
                }
                else
                {
                    data_name = "NOMBRE NO ENCONTRADO";
                }

                data_code = listColors.data[c].color.ToUpper().Trim().Replace(" ", "");
                data_pant = listColors.data[c].pantone_value.ToUpper().Trim().Replace(" ", "");

                result.Add(new viewData
                {
                    year = data_year,
                    name = data_name,
                    code = data_code,
                    pantone = data_pant
                });
            }

            if (listColors.total_pages == page)
            {
                next_page = "disabled";
            }

            if (listColors.page == 1)
            {
                prev_page = "disabled";
            }

            data_color = result;
        }
    }
}