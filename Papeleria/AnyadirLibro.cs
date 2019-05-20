using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Bukimedia.PrestaSharp.Entities;
using Bukimedia.PrestaSharp.Factories;

namespace Papeleria
{
    public partial class AnyadirLibro : Form
    {
        
        const string BASEURL = "http://papeleriamaribel.com/api";
        const string PASS = "";

        ProductFactory pf;
        ProductFeatureValueFactory pfvf;
        CategoryFactory cf;
        StockAvailableFactory saf;
        ImageFactory imageFactory;

        product producto;

        List<String> imagenes;
        List<long> checkedCategories;
        Dictionary<int, TreeNode> dic;

        long idISBN, idEditorial, idCurso, idEstado, idIdioma;

        public AnyadirLibro()
        {
            InitializeComponent();

            saf = new StockAvailableFactory(BASEURL, KEYStocks, PASS);
            pf = new ProductFactory(BASEURL, KEYProds, PASS);
            pfvf = new ProductFeatureValueFactory(BASEURL, KEYFeaturesValues, PASS);
            cf = new CategoryFactory(BASEURL, KEYCategories, PASS);
            imageFactory = new ImageFactory(BASEURL, KEYImages, PASS);
            //pff = new ProductFeatureFactory(BASEURL, KEYFeatures, PASS);

            imagenes = new List<String>();
            checkedCategories = new List<long>();

            fill();
        }

        private void fill()
        {
            txt_cantidad.Text = "1";
            fillEstado();
            fillEditorial();
            fillCurso();
            fillIdioma();
            fillCategorias();
        }
        private void fillEstado()
        {
            var datasource = new List<String>();
            datasource.Add("Nuevo");
            datasource.Add("Como nuevo");
            datasource.Add("Muy bueno");
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
                datasource.Add(each.value[0].Value);
            }
            cb_editorial.Sorted = true;
            cb_editorial.DataSource = datasource;

        }
        private void fillCurso()
        {
            var datasource = new List<String>();
            Dictionary<String, String> d = new Dictionary<string, string>();
            d.Add("id_feature", "6");
            var lista = pfvf.GetByFilter(d, null, null);
            foreach (product_feature_value each in lista)
            {
                datasource.Add(each.value[0].Value);
            }
            cb_curso.Sorted = true;
            cb_curso.DataSource = datasource;

        }
        private void fillIdioma()
        {
            var datasource = new List<String>();
            Dictionary<String, String> d = new Dictionary<string, string>();
            d.Add("id_feature", "11");
            var lista = pfvf.GetByFilter(d, null, null);
            foreach (product_feature_value each in lista)
            {
                datasource.Add(each.value[0].Value);
            }
            cb_idioma.Sorted = true;
            cb_idioma.DataSource = datasource;
        }
        private void fillCategorias()
        {
            //lista[0] = root y lista[1] = home
            dic = new Dictionary<int, TreeNode>();
            var lista = cf.GetAll();
            TreeNode home = tv_categories.Nodes.Add("1 - " + lista[1].name[0].Value);
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
            TreeNode home, libros;
            d.TryGetValue(2, out home);
            d.TryGetValue(4, out libros);
            home.Checked = true;
            libros.Checked = true;
        }


        private void createProduct()
        {
            producto = new product();
            setISBN();
            setName();
            setTags(); //TODO
            setExtras();
            setPrecio();
            setEstado();
            //setCantidad();
            setCaracteristicas();
            setCategorias();
            setDescripcion();
            //setImagenes();
        }

        private void setISBN()
        {
            producto.ean13 = txt_isbn.Text;
        }
        private void setName()
        {
            string nombre = mejoraNombre(txt_nombre.Text);
            producto.name.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, nombre));
            producto.meta_title.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, nombre));
            producto.meta_keywords.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, nombre));

        }
        private void setTags()
        {
            //TODO 
            /*string[] palabras = (rtxt_descripcion.Text).Split(' ');
            List<Bukimedia.PrestaSharp.Entities.tag> Tags = TagsController.GetPrestaSharpTagsFromSendProduct(product, this.CatalogMemory);
            foreach (string each in palabras)
            {
                producto.associations.tags.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.tag())
            }

            foreach (Bukimedia.PrestaSharp.Entities.tag tag in Tags)
            {


            }*/
        } //TODO
        private void setExtras()
        {
            producto.active = 1;
            producto.show_price = 1;
            producto.available_for_order = 1;
            producto.is_virtual = 0;
            producto.visibility = "both";
            producto.advanced_stock_management = 0;
            //p.date_add = "2017-10-11 11:15:20";
            producto.id_tax_rules_group = 1;
            //p.id_shop_default = 1;
            //MiArticulo.price = Convert.ToDecimal(10.99);
            //lenguajes.Value = "Name";
            //p.AddLinkRewrite(Lenguaje);

        }
        private void setPrecio()
        {
            double ptax = convierteStringADouble(txt_precio.Text);
            double p = Math.Round(ptax / 1.21,2);
            producto.price = Convert.ToDecimal(p);
            producto.id_tax_rules_group = 4;
            //IVA 4 = 21%, IVA 8 = 4%
        }
        private void setEstado()
        {
            //new, used, refurbished
            string seleccion = cb_estado.SelectedItem.ToString();
            if (seleccion == "Nuevo") producto.condition = "new";
            else producto.condition = "used";

        }
        private void setCantidad() //POST CREACION
        {
            producto.minimal_quantity = 1;
            int cdad = 1;
            string leido = txt_cantidad.Text;
            try { cdad = int.Parse(leido); }
            catch (FormatException fe) { Console.Write("Error en setCantidad: " + fe.Message); }

        }
        private void setCaracteristicas()
        {
            setCaracteristicaISBN();
            setCaracteristicaEditorial();
            setCaracteristicaCurso();
            setCaracteristicaEstado();
            setCaracteristicaIdioma();
        }
        private void setCaracteristicaISBN()
        {
            Dictionary<String, String> diccionario = new Dictionary<string, string>();
            diccionario.Add("id_feature", "4");
            var lista = pfvf.GetByFilter(diccionario, null, null);
            product_feature_value feature = new product_feature_value();
            feature.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, txt_isbn.Text));
            //long idISBN = (long)newISBN.id_feature;
            lista.Add(feature);
        }
        private void setCaracteristicaEditorial()
        {
            Dictionary<String, String> diccionario = new Dictionary<string, string>();
            diccionario.Add("id_feature", "5");
            var lista = pfvf.GetByFilter(diccionario, null, null);
            product_feature_value feature = new product_feature_value();
            feature.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, cb_editorial.Text));
            lista.Add(feature);
        }
        private void setCaracteristicaCurso()
        {
            Dictionary<String, String> diccionario = new Dictionary<string, string>();
            diccionario.Add("id_feature", "6");
            //var lista = pfvf.GetByFilter(diccionario, null, null);
            product_feature_value feature = new product_feature_value();
            feature.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, cb_editorial.Text));
            //lista.Add(feature);
            //producto.associations.product_features.Add(feature)

            //product_feature_value cursoEscogido = new product_feature_value();
            //cursoEscogido.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, cb_curso.SelectedItem.ToString()));
        }
        private void setCaracteristicaEstado()
        {
            Dictionary<String, String> diccionario = new Dictionary<string, string>();
            diccionario.Add("id_feature", "10");
            var lista = pfvf.GetByFilter(diccionario, null, null);
            product_feature_value feature = new product_feature_value();
            feature.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, cb_estado.Text));
            lista.Add(feature);
        }
        private void setCaracteristicaIdioma()
        {
            Dictionary<String, String> diccionario = new Dictionary<string, string>();
            diccionario.Add("id_feature", "11");
            var lista = pfvf.GetByFilter(diccionario, null, null);
            product_feature_value feature = new product_feature_value();
            feature.value.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, cb_idioma.Text));
            lista.Add(feature);
        }

        private void setCategorias()
        {
            getCheckedNodes(tv_categories.Nodes);
            producto.id_category_default = 4;
            //producto.associations.categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category(2));
        }



        private void setDescripcion()
        {
            string descripcion = mejoraNombre(rtxt_descripcion.Text);
            producto.description_short.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.language((long)3, descripcion));
        }
        private void setImagenes()
        {
            foreach (String url in imagenes)
            {
                imageFactory.AddProductImage((long)producto.id, url);
            }
        }

        private void updateProduct()
        {
            setCantidad();
            setImagenes();
        }
        
        private Boolean checkFields()
        {
            return true;
        }
        private void cb_idioma_SelectedIndexChanged(object sender, EventArgs e)
        {

        } //TODO

        //Imagenes
        private void btn_add_product(object sender, EventArgs e)
        {
            if (checkFields())
            {
                createProduct();
                pf.Add(producto);
                updateProduct();

            }
        }    
        private void btn_add_img(object sender, EventArgs e)
        {

            var dialog = new OpenFileDialog();
            string file = "";
            dialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop).ToString();
            dialog.Title = "Seleccione  una imagen";
            dialog.Multiselect = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (String f in dialog.FileNames)
                {
                    //file = dialog.FileName;
                    imagenes.Add(f);
                    updListaImagenes();
                }

            }

        }
        private void btn_del_img(object sender, EventArgs e)
        {
            if (lb_imagenes.SelectedItems != null)
            {
                foreach (String each in lb_imagenes.SelectedItems)
                {
                    imagenes.Remove(each);
                }
                updListaImagenes();
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
            txt_nombre.Text = "Nombre de prueba";
            txt_cantidad.Text = "1";
            txt_isbn.Text = "";
            txt_precio.Text = "9.95";
            txt_isbn.Text = "1234567890123";
            rtxt_descripcion.Text = "Parrafo1.\nParrafo2";
        }

        //Aux methods
        public void getCheckedNodes(TreeNodeCollection nodes)
        {
            foreach (TreeNode aNode in nodes)
            {
                //edit
                if (aNode.Checked)
                {
                    string substring = aNode.Text.Substring(0, 1);
                    long id = long.Parse(substring);
                    checkedCategories.Add(id);
                    producto.associations.categories.Add(new Bukimedia.PrestaSharp.Entities.AuxEntities.category(id));
                }
                if (aNode.Nodes.Count != 0)
                    getCheckedNodes(aNode.Nodes);
            }
        }
        private string mejoraNombre(String n)
        {
            string primera = "" + n[0];
            primera = primera.ToUpper();
            return primera + n.Substring(1);
        }
        private double convierteStringADouble(String leido)
        {
            double precio = 0;
            leido = leido.Replace('.', ',');
            try
            {
                precio = Double.Parse(leido);
            }
            catch (FormatException fe)
            {
                Console.Write("Error en convierteStringADouble: " + fe.Message);
                return -1;

            }
            return precio;
        }

    }
}
