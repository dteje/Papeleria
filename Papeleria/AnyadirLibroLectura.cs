using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Papeleria
{
    public partial class AnyadirLibroLectura : Form
    {

        const string BASEURL = "https://papeleriamaribel.com/api";
        const string PASS = "";

        product pro;
        ProductFactory pf;
        ProductFeatureValueFactory pfvf;
        CategoryFactory cf;
        StockAvailableFactory saf;
        ImageFactory imageFactory;
        ProductFeatureFactory pff;
        TagFactory tf;

        bool ok;

        product producto;

        List<String> imagenes, defCategories;
        List<long> checkedCategories;
        Dictionary<int, TreeNode> dic;

        Dictionary<string, long> dicIdioma, dicEditorial, dicFormato, dicEstado;

        public AnyadirLibroLectura()
        {
            InitializeComponent();
            saf = new StockAvailableFactory(BASEURL, KEYStocks, PASS);
            pf = new ProductFactory(BASEURL, KEYProds, PASS);
            pfvf = new ProductFeatureValueFactory(BASEURL, KEYFeaturesValues, PASS);
            cf = new CategoryFactory(BASEURL, KEYCategories, PASS);
            imageFactory = new ImageFactory(BASEURL, KEYImages, PASS);
            pff = new ProductFeatureFactory(BASEURL, KEYFeatures, PASS);
            tf = new TagFactory(BASEURL, KEYTags, PASS);

            ok = true;

            imagenes = new List<String>();
            checkedCategories = new List<long>();
            defCategories = new List<String>();
            dicFormato = new Dictionary<string, long>();
            dicEditorial = new Dictionary<string, long>();
            dicIdioma = new Dictionary<string, long>();
            dicEstado = new Dictionary<string, long>();
            fill();
        }

        //Fill: todo lo que se hace al abrir el formulario
        private void fill()
        {
            txt_cantidad.Text = "1";
            fillEstado();
            fillEditorial();
            fillFormato();
            fillIdioma();
            fillCategorias();
        }
        private void fillEstado()
        {
            var datasource = new List<String>();
            Dictionary<String, String> d = new Dictionary<string, string>();
            d.Add("id_feature", "10");
            var lista = pfvf.GetByFilter(d, null, null);
            foreach (product_feature_value each in lista)
            {
                dicEstado.Add(each.value[0].Value, (long)each.id);
                //datasource.Add(each.value[0].Value);
            }
            datasource.Add("Nuevo");
            datasource.Add("Como nuevo");
            datasource.Add("Bueno");
            datasource.Add("Regular");
            datasource.Add("Aceptable");
            cb_estado.DataSource = datasource;
            cb_estado.DropDownStyle = ComboBoxStyle.DropDownList;

        }
        private void fillEditorial()
        {
            var datasource = new List<String>();
            Dictionary<String, String> d = new Dictionary<string, string>();
            d.Add("id_feature", "5");
            var lista = pfvf.GetByFilter(d, null, null);
            foreach (product_feature_value each in lista)
            {
                dicEditorial.Add(each.value[0].Value, (long)each.id);
                datasource.Add(each.value[0].Value);
            }
            cb_editorial.Sorted = true;
            cb_editorial.DataSource = datasource;

        }
        private void fillFormato()
        {
            var datasource = new List<String>();
            Dictionary<String, String> d = new Dictionary<string, string>();
            d.Add("id_feature", "14");
            var lista = pfvf.GetByFilter(d, null, null);
            foreach (product_feature_value each in lista)
            {
                dicFormato.Add(each.value[0].Value, (long)each.id);
                datasource.Add(each.value[0].Value);
            }
            cb_formato.Sorted = true;
            cb_formato.DataSource = datasource;
            cb_formato.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void fillIdioma()
        {
            var datasource = new List<String>();
            Dictionary<String, String> d = new Dictionary<string, string>();
            d.Add("id_feature", "11");
            var lista = pfvf.GetByFilter(d, null, null);
            foreach (product_feature_value each in lista)
            {
                dicIdioma.Add(each.value[0].Value, (long)each.id);
                datasource.Add(each.value[0].Value);
            }
            cb_idioma.Sorted = true;
            cb_idioma.DataSource = datasource;
            cb_idioma.SelectedIndex = 1;
            cb_idioma.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void fillCategorias()
        {
            //lista[0] = root y lista[1] = home
            dic = new Dictionary<int, TreeNode>();
            var lista = cf.GetAll();
            TreeNode home = tv_categories.Nodes.Add("2 - " + lista[1].name[0].Value);
            dic.Add(2, home);
            foreach (category each in lista)
            {
                if (each.is_root_category == 0 && each.active == 1 && each.id != 1)
                {
                    TreeNode parentnode, node;
                    if (dic.TryGetValue((int)each.id_parent, out parentnode))
                    {
                        node = parentnode.Nodes.Add(each.id + " - " + each.name[0].Value);
                    }
                    else
                    {
                        node = home.Nodes.Add(each.id + " - " + each.name[0].Value);
                    }
                    dic.Add((int)each.id, node);
                }
            }
            tv_categories.ExpandAll();
            tv_categories.CheckBoxes = true;
            checkCategories(dic);
        }
        private void checkCategories(Dictionary<int, TreeNode> d)
        {
            //Marca las casillas de Home y de Libros al iniciar la pantalla
            TreeNode home, libros, lectura, juegos, papeleria;
            d.TryGetValue(2, out home);
            d.TryGetValue(3, out juegos);
            d.TryGetValue(4, out libros);
            d.TryGetValue(29, out lectura);
            d.TryGetValue(12, out papeleria);
            home.Checked = true;
            libros.Checked = true;
            lectura.Checked = true;
            juegos.Collapse();
            papeleria.Collapse();
        }


        private void btn_add_product(object sender, EventArgs e)
        {
            ok = true;
            if (ok) createProduct();
            if (ok && checkUpdateFieldsBeforeAdd()) pro = pf.Add(producto);
            if (ok) updateProduct();
        }

        //lo que se hace antes de subir el producto
        private void createProduct()
        {
            producto = new product();
            while (ok)
            {
                if (!setISBN()) break;
                if (!setName()) break;
                if (!setTags()) break;
                if (!setMetaData()) break;
                if (!setExtras()) break;
                if (!setPrecio()) break;
                if (!setEstado()) break;
                if (!setCategorias()) break;
                if (!setDescripcion()) break;
                break;
            }
        }
        private bool setISBN()
        {
            try
            {
                producto.ean13 = txt_isbn.Text;
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("El ISBN no es correcto.", "Ups!");
                ok = false;
                return false;
            }
        }
        private bool setName()
        {
            try
            {
                string nombre = mejoraNombre(txt_nombre.Text);
                producto.name.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, nombre));
                producto.meta_title.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, nombre));
                producto.meta_keywords.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, nombre));
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("1 - El nombre no es correcto.", "Ups!");
                ok = false;
                return false;
            }

        }
        private bool setTags()
        {
            try
            {
                string[] palabras = (txt_nombre.Text.Split(' '));
                foreach (string palabra in palabras)
                {
                    tag tag = new tag();
                    tag.id_lang = 3;
                    tag.name = palabra;
                    tag = tf.Add(tag);
                    producto.associations.tags.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.tag((long)tag.id));
                }

                /*string[] palabras = (rtxt_descripcion.Text).Split(' ');
                List<Bukimedia.PrestaSharp.Entities.tag> Tags = TagsController.GetPrestaSharpTagsFromSendProduct(product, this.CatalogMemory);
                foreach (string each in palabras)
                {
                    producto.associations.tags.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.tag())
                }

                foreach (Bukimedia.PrestaSharp.Entities.tag tag in Tags)
                {


                }*/
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("El nombre no es correcto. (Error: etiquetas)", "Ups!");
                ok = false;
                return false;
            }
        }
        private bool setMetaData()
        {
            //https://github.com/Bukimedia/PrestaSharp/issues/95
            return true;
        }
        private bool setExtras()
        {
            producto.active = 1;
            producto.show_price = 1;
            producto.available_for_order = 1;
            producto.is_virtual = 0;
            producto.visibility = "both";
            producto.advanced_stock_management = 0;
            producto.minimal_quantity = 1;
            try
            {
                if (ok) producto.AddLinkRewrite(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, producto.name[0].Value));
            }
            catch (Exception e)
            {
                ok = false;
            }

            //p.date_add = "2017-10-11 11:15:20";
            producto.id_tax_rules_group = 1;
            //p.id_shop_default = 1;
            //MiArticulo.price = Convert.ToDecimal(10.99);
            //lenguajes.Value = "Name";
            //p.AddLinkRewrite(Lenguaje);
            return ok;

        }
        private bool setPrecio()
        {
            try
            {
                double ptax = convierteStringADouble(txt_precio.Text);
                double p = Math.Round(ptax / 1.21, 2);
                producto.price = Convert.ToDecimal(p);
                producto.id_tax_rules_group = 4;
                //IVA 4 = 21%, IVA 8 = 4%
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("El precio no es correcto.", "Ups!");
                ok = false;
                return false;
            }
        }
        private bool setEstado()
        {
            try
            {
                string seleccion = cb_estado.SelectedItem.ToString();
                if (seleccion == "Nuevo") producto.condition = "new";
                else producto.condition = "used";
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("El estado no es correcto.", "Ups!");
                ok = false;
                return false;
            }
            //new, used, refurbished


        }
        private bool setCategorias()
        {
            try
            {
                foreach (long cat in checkedCategories)
                {
                    producto.associations.categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category(cat));
                }
                //producto.associations.categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category(1));            
                producto.id_category_default = Int64.Parse(cb_categoria.Text.Substring(0, 2));
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Parece que hay un problema con las categorías.", "Ups!");
                ok = false;
                return false;
            }
        }
        private bool setDescripcion()
        {
            try
            {
                string descripcion = mejoraNombre(rtxt_descripcion.Text);
                producto.description_short.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, descripcion));
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("La descripción no es correcta.", "Ups!");
                ok = false;
                return false;
            }
        }

        //Atributos y características que se actualizan tras crear el producto
        private void updateProduct()
        {
            while (ok)
            {
                if (!setCantidad()) break;
                if (!setImagenes()) break;
                if (!setCaracteristicas()) break;
                System.Windows.Forms.MessageBox.Show("¡Producto subido!", "Perfecto");
                break;
            }


        }
        private bool setCantidad()
        {
            int cdad = 1;
            string leido = txt_cantidad.Text;
            try
            {
                cdad = int.Parse(leido);
                long id = (long)pro.id;
                Dictionary<String, String> dic = new Dictionary<String, String>();
                dic.Add("id_product", id.ToString());
                List<stock_available> lstocks = saf.GetByFilter(dic, null, null);
                lstocks[0].quantity = cdad;
                saf.Update(lstocks[0]);
                return true;
            }
            catch (FormatException fe)
            {
                System.Windows.Forms.MessageBox.Show("Error en la cantidad", "Ups");
                ok = false;
                return false;
            }

        }
        private bool setImagenes()
        {
            try
            {
                foreach (String url in imagenes)
                {

                    imageFactory.AddProductImage((long)pro.id, url);
                }
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error en las imágenes", "Ups!");
                ok = false;
                return false;
            }

        }
        private bool setCaracteristicas()
        {
            while (ok)
            {
                if (!setCaracteristicaISBN()) break;
                if (!setCaracteristicaEditorial()) break;
                //if (!setCaracteristicaCurso()) break;
                if (!setCaracteristicaEstado()) break;
                if (!setCaracteristicaIdioma()) break;
                if (!setCaracteristicaAnyo()) break;
                if (!setCaracteristicaFormato()) break;
                if (!setCaracteristicaAutor()) break;
                break;
            }
            return ok;
        }

        private bool setCaracteristicaAnyo()
        {
            try
            {
                product_feature_value feature = new product_feature_value();
                feature.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, txt_year.Text));
                feature.id_feature = 15;

                feature = pfvf.Add(feature);

                Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature pf1 = new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature();
                pf1.id = 15;
                pf1.id_feature_value = (long)feature.id;
                pro.associations.product_features.Add(pf1);
                pf.Update(pro);
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error en el año", "Ups!");
                ok = false;
                return false;
            }
        }
        private bool setCaracteristicaISBN()
        {
            try
            {
                product_feature_value feature = new product_feature_value();
                feature.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, txt_isbn.Text));
                feature.id_feature = 4;

                feature = pfvf.Add(feature);

                Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature pf1 = new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature();
                pf1.id = 4;
                pf1.id_feature_value = (long)feature.id;
                pro.associations.product_features.Add(pf1);
                pf.Update(pro);
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error en el ISBN", "Ups!");
                ok = false;
                return false;
            }

        }
        private bool setCaracteristicaEditorial()
        {
            try
            {
                if (!dicEditorial.TryGetValue(cb_editorial.Text, out long rep))
                {
                    product_feature_value v = new product_feature_value();
                    v.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, cb_editorial.Text));
                    v.id_feature = 5;
                    v = pfvf.Add(v);
                    rep = (long)v.id;
                }
                Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature pf1 = new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature();
                pf1.id = 5;
                pf1.id_feature_value = rep;
                pro.associations.product_features.Add(pf1);
                pf.Update(pro);
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error en la editorial", "Ups!");
                ok = false;
                return false;
            }
        }
        private bool setCaracteristicaFormato()
        {
            try
            {
                Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature pf1 = new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature();
                pf1.id = 14;
                String key = cb_formato.Text.ToString();
                pf1.id_feature_value = (long)dicFormato[key];
                pro.associations.product_features.Add(pf1);
                pf.Update(pro);
                return true;
            }
            catch (Exception e)
            {
                ok = false;
                System.Windows.Forms.MessageBox.Show("Error en el formato", "Ups!");
                return false;
            }
        }
        private bool setCaracteristicaEstado()
        {
            try
            {
                long rep = dicEstado[cb_estado.Text];
                Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature pf1 = new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature();
                pf1.id = 10;
                pf1.id_feature_value = rep;
                pro.associations.product_features.Add(pf1);
                pf.Update(pro);
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error en el estado", "Ups!");
                ok = false;
                return false;
            }
        }
        private bool setCaracteristicaIdioma()
        {
            try
            {
                Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature pf1 = new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature();
                pf1.id = 11;
                String key = cb_idioma.Text.ToString();
                pf1.id_feature_value = (long)dicIdioma[key];
                pro.associations.product_features.Add(pf1);
                pf.Update(pro);
                return true;
            }
            catch (Exception e)
            {
                ok = false;
                System.Windows.Forms.MessageBox.Show("Error en el idioma", "Ups!");
                return false;
            }
        }
        private bool setCaracteristicaAutor()
        {
            try
            {
                product_feature_value feature = new product_feature_value();
                feature.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, txt_author.Text));
                feature.id_feature = 13;

                feature = pfvf.Add(feature);

                Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature pf1 = new Bukimedia.PrestaSharp.Entities.AuxEntities.product_feature();
                pf1.id = 13;
                pf1.id_feature_value = (long)feature.id;
                pro.associations.product_features.Add(pf1);
                pf.Update(pro);
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error en el autor", "Ups!");
                ok = false;
                return false;
            }

        }

        //Aux methods
        private bool checkUpdateFieldsBeforeAdd()
        {
            //Comprueba si las características, cantidad e imágenes están ok antes de crear el producto
            if (cb_formato.Text.Length == 0)
            {
                ok = false;
                System.Windows.Forms.MessageBox.Show("Error en el curso", "Ups!");
                return false;
            }
            if (cb_editorial.Text.Length == 0)
            {
                ok = false;
                System.Windows.Forms.MessageBox.Show("Error en la editorial", "Ups!");
                return false;
            }
            try
            {
                int cdad = int.Parse(txt_cantidad.Text);
            }
            catch (Exception e)
            {
                ok = false;
                System.Windows.Forms.MessageBox.Show("Error en la cantidad", "Ups!");
                return false;
            }
            try
            {
                if (txt_isbn.Text.Length == 0) throw new Exception();
                return true;
            }
            catch (Exception e)
            {
                System.Windows.Forms.MessageBox.Show("Error en el ISBN", "Ups!");
                ok = false;
                return false;
            }
        }

        private string mejoraNombre(String n)
        {
            try
            {
                string primera = "" + n[0];
                primera = primera.ToUpper();
                return primera + n.Substring(1);
            }
            catch (Exception e)
            {
                ok = false;
                throw e;
            }
        }
        private double convierteStringADouble(String leido)
        {
            double precio = 0;
            leido = leido.Replace('.', ','); //Cambio de , a . en MNPro
            try
            {
                precio = Double.Parse(leido);
            }
            catch (FormatException fe)
            {
                ok = false;
                System.Windows.Forms.MessageBox.Show("El precio no es correcto.", "Ups!");
                return -1;

            }
            if (precio == 0)
            {
                ok = false;
                System.Windows.Forms.MessageBox.Show("El precio no puede ser nulo.", "Ups!");
            }
            return precio;
        }
        private void tv_categories_AfterCheck(object sender, TreeViewEventArgs e)
        {
            String txt = e.Node.Text;
            long id = Int64.Parse(txt.Substring(0, 2));
            if (e.Node.Checked)
            {

                checkedCategories.Add(id);
                defCategories.Add(txt);
            }
            else
            {
                checkedCategories.Remove(id);
                defCategories.Remove(txt);

            }
            cb_categoria.DataSource = null;
            cb_categoria.DataSource = defCategories;
            cb_categoria.SelectedIndex = cb_categoria.Items.Count - 1;


        }

        private void btn_back(object sender, EventArgs e)
        {
            this.Close();
        }


        //Imagenes
        private void btn_add_img(object sender, EventArgs e)
        {

            var dialog = new OpenFileDialog();
            string file = "";
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
            dialog.Title = "Seleccione una imagen";
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String f in dialog.FileNames)
                {
                    long size = new FileInfo(f).Length;
                    if (size < 2999999)
                    {
                        //file = dialog.FileName;
                        imagenes.Add(f);
                        updListaImagenes();
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("Una o varias imágenes superan el tamaño máximo permitido (3MB)", "Ups!");


                    }
                }

            }

        }
        private void btn_del_img(object sender, EventArgs e)
        {
            if (lb_imagenes.SelectedItems.Count > 0)
            {
                foreach (String each in lb_imagenes.SelectedItems)
                {
                    imagenes.Remove(each);
                }
                updListaImagenes();
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Debes seleccionar al menos una imagen para poder eliminarla", "Ups!");
            }
        }
        private void updListaImagenes()
        {
            lb_imagenes.Items.Clear();
            foreach (String each in imagenes)
            {
                lb_imagenes.Items.Add(each);
            }

        }
        //FakeData
        private void btn_fakedata(object sender, EventArgs e)
        {
            txt_nombre.Text = "Artículo";
            txt_cantidad.Text = "2";
            txt_precio.Text = "9.95";
            txt_isbn.Text = "1234567890123";
            rtxt_descripcion.Text = "Parrafo1.\nParrafo2";
        }

    }
}
