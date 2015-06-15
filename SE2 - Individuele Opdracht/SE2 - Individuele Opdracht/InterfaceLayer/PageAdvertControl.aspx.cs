using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SE2___Individuele_Opdracht.InterfaceLayer
{
    public partial class PageAdvertControl : System.Web.UI.Page
    {
        private AdvertControl advertControl = new AdvertControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            dropdownAdvertControlMyAdvertsAdverts.Items.Clear();

            foreach (Advert advert in advertControl.Adverts)
            {
                dropdownAdvertControlMyAdvertsAdverts.Items.Add(advert.Title);
            }
        }

        protected void dropdownAdvertControlMyAdvertsAdverts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdownAdvertControlMyAdvertsAdverts.SelectedIndex != -1)
            {
                foreach (Advert advert in advertControl.Adverts)
                {
                    if (advert.Title == dropdownAdvertControlMyAdvertsAdverts.Text)
                    {
                        Advert advert1 = advert;

                        lblAdvertControlMyAdvertsTitle.Text = advert1.Title;
                        lblAdvertControlMyAdvertsCreationDate.Text = Convert.ToString(advert1.CreationDate);
                        lblAdvertControlMyAdvertsViews.Text = Convert.ToString(advert1.Views);
                        lblAdvertControlMyAdvertsCategory.Text = Convert.ToString(advert1.CategoryID);
                    }
                }

            }
        }
    }
}