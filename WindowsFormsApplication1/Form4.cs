using System;
using System.Linq;
using System.Windows.Forms;
using Entities;
using Repositories;

namespace WindowsFormsApplication1
{
    public partial class Form4 : Form
    {
        private readonly AQLM2Entities context;
        private readonly DateTime dateFinish;
        private readonly DateTime dateStart;
        private readonly InsertRepositories insertRepositories;
        private readonly String mat;
        private readonly PiloteRepositories pil;
        private readonly PiloteFini pilInsert;
        private readonly PiloteFiniRepositories pilr;
        private readonly ValOKdIntegrepositories repo;
        private OkDescriptRepositorie desc;
        private bool err;

        public Form4()
        {
            InitializeComponent();
            context = new AQLM2Entities();
            repo = new ValOKdIntegrepositories(context);
            desc = new OkDescriptRepositorie(context);
            insertRepositories = new InsertRepositories();
            dateStart = insertRepositories.getDateEquipe();
            dateFinish = insertRepositories.getDateFINEquipe(dateStart);
            pil = new PiloteRepositories(context);
            pilr = new PiloteFiniRepositories(context);
            pilInsert = new PiloteFini();
            err = false;
        }

        public Form4(String mat)
        {
            InitializeComponent();
            this.mat = mat;
            context = new AQLM2Entities();
            repo = new ValOKdIntegrepositories(context);
            desc = new OkDescriptRepositorie(context);
            insertRepositories = new InsertRepositories();
            dateStart = insertRepositories.getDateEquipe();
            dateFinish = insertRepositories.getDateFINEquipe(dateStart);
            pil = new PiloteRepositories(context);
            pilr = new PiloteFiniRepositories(context);
            pilInsert = new PiloteFini();
            err = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var err = false;
            RadioButton[] l = {ContHDDrb1Ok, ContHDDrb1NOk, ContHDDrb1Na};

            RadioButton[] listNok = {ContHDDrb1NOk};


            var insert = new InsertRepositories(ConHDDCom, listNok, l, ValidContHDD, ConHDDCom.Text);
            insert.checkNokRb(err);
            var msg = "";

            if (!String.IsNullOrEmpty(ConHDDCom.Text))
            {
                msg = ConHDDCom.Text;
            }

            //int dd = desc.Get(bd =>bd.description.Equals(lbPpalet.Text)&& bd.poste.Equals("Intégration ADT") && bd.module.Equals("Poste Paléttisation")).Select(bd => bd.id).First();
            //incrémentaion d'id
            for (var i = 0; i < l.Length - 2; i += 3)
            {
                var v = new ValOKdIntegrtion();

                v.date = DateTime.Now;
                //v.idLigne = 5;
                var pl = pil.Get(bb => bb.matricule.Equals(mat)).SingleOrDefault();
                pilInsert.matricule = pl.matricule;
                pilInsert.nom = pl.nom + " " + pl.prenom;

                pilInsert.poste = pl.poste;
                pilInsert.date = DateTime.Now;
                pilInsert.module = navigationPage5.Caption;
                var b = true;
                var c = false;
                v.ok = c;
                v.nok = c;
                v.na = c;
                if (l[i].Checked)
                {
                    v.ok = b;
                    v.idDescription = 139;
                    repo.Insert(v);
                }
                else if (l[i + 1].Checked)
                {
                    v.nok = b;
                    v.idDescription = 139;
                    //dd++;
                    v.commentaire = msg;
                    repo.Insert(v);
                }
                else
                {
                    v.na = b;
                    v.idDescription = 139;
                    //dd++;
                    repo.Insert(v);
                }
            }
            if (err == false)
            {
                pilr.Insert(pilInsert);
                ValidContHDD.Enabled = false;
                MessageBox.Show("Succés validation !", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void backMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();

            var f = new Form5();
            f.ShowDialog();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            var pfi = new PiloteFiniRepositories(context);
            var poste =
                pfi.Get(p => p.date > dateStart && p.date < dateFinish && p.poste.Equals("TQP"))
                    .Select(p => p.module)
                    .ToList();
            foreach (var d in poste)
            {
                if (d.Equals(navigationPage5.Caption))
                {
                    ValidContHDD.Enabled = false;
                }
            }
        }
    }
}