using System;
using System.Linq;
using System.Windows.Forms;
using Entities;
using Repositories;

namespace OKDemarrageIntegration
{
    public partial class Form5 : Form
    {
        private  AQLM2Entities context;
        private  DateTime dateFinish;
        private  DateTime dateStart;
        private  InsertRepositories insertRepositories;
        private  PiloteFiniRepositories pfi;
        private OkDescriptRepositorie desc;
        private PiloteFini pf;
        private PiloteRepositories pil;
        private ValOKdIntegrepositories repo;

        public Form5()
        {
            InitializeComponent();
            context = new AQLM2Entities();
            repo = new ValOKdIntegrepositories(context);
            desc = new OkDescriptRepositorie(context);
            insertRepositories = new InsertRepositories();
            pil = new PiloteRepositories(context);
            pfi = new PiloteFiniRepositories(context);
            pf = new PiloteFini();
            dateStart = insertRepositories.getDateEquipe();
            dateFinish = insertRepositories.getDateFINEquipe(dateStart);
            
        
            private void button1_Click(object sender, EventArgs e)
            {

            var pilote = new PiloteRepositories(context);
            var validUser = false;
            var userElement =
                pilote.Get(u => u.matricule.Equals(LoginHome.Text) && u.pwd.Equals(motdepasse.Text))
                    .SingleOrDefault();


            validUser = (userElement != null);
            if (validUser)
            {
                if (userElement.poste.Equals("TQP"))
                {
                    Hide();
                    var dem = new Form4(LoginHome.Text);
                    dem.Show();
                }
                else if (userElement.poste.Equals("CE"))
                {
                    Hide();
                    var dem = new Form1(LoginHome.Text);
                    dem.Show();
                }
                else
                {
                    MessageBox.Show("login ou mot de passe incorrecte !", "Login Failed", MessageBoxButtons.OK,
                        MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show("login ou mot de passe incorrecte !", "Login Failed", MessageBoxButtons.OK,
                    MessageBoxIcon.Stop);
            }
        }}

        private void Form5_Load(object sender, EventArgs e)
        {
            displayList(dateStart, dateFinish, 3, "TQP");
            displayList(dateStart, dateFinish, 17, "CE");
        }

        private void displayList(DateTime dateStart, DateTime dateFinish, int test, String fonction)
        {
            try
            {
                listPiloteFini.Items.Clear();

                // Array data;
                var data =
                    pfi.Get(dt => dt.date >= dateStart && dt.date <= dateFinish)
                        .Select(dt => new {dt.matricule, dt.nom, dt.module})
                        .Distinct()
                        .ToList();
                // Console.Write(data.GetValue(0).ToString());

                var cont =
                    pfi.Get(b => b.poste.Equals(fonction) && b.date >= dateStart && b.date <= dateFinish)
                        .Select(c => c.module)
                        .Count();

                if (cont == test)
                {
                    foreach (var d in data)
                    {
                        var item = new ListViewItem();
                        item.Text = d.matricule;
                        item.SubItems.Add(d.nom);

                        item.SubItems.Add(d.module);
                        listPiloteFini.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }
}