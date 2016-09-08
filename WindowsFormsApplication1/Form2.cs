using System;
using System.Linq;
using System.Windows.Forms;
using Repositories;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private readonly AQLM2Entities context;
        private readonly DateTime dateFinish;
        private readonly DateTime dateStart;
        private readonly OkDescriptRepositorie desc;
        private readonly bool err;
        private readonly InsertRepositories insertRepositories;
        private readonly String mat;
        private readonly ValOKdIntegrepositories repo;
        private string input;

        public Form1()
        {
            InitializeComponent();
            context = new AQLM2Entities();
            repo = new ValOKdIntegrepositories(context);
            desc = new OkDescriptRepositorie(context);
            insertRepositories = new InsertRepositories();
            dateStart = insertRepositories.getDateEquipe();
            dateFinish = insertRepositories.getDateFINEquipe(dateStart);
            err = false;
        }

        public Form1(String mat)
        {
            InitializeComponent();
            context = new AQLM2Entities();

            insertRepositories = new InsertRepositories();
            dateStart = insertRepositories.getDateEquipe();
            dateFinish = insertRepositories.getDateFINEquipe(dateStart);
            repo = new ValOKdIntegrepositories(context);
            desc = new OkDescriptRepositorie(context);
            err = false;
            this.mat = mat;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void radioButton26_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void label14_Click(object sender, EventArgs e)
        {
        }

        private void label17_Click(object sender, EventArgs e)
        {
        }

        private void label18_Click(object sender, EventArgs e)
        {
        }

        private void label19_Click(object sender, EventArgs e)
        {
        }

        private void label12_Click(object sender, EventArgs e)
        {
        }

        private void label14_Click_1(object sender, EventArgs e)
        {
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void label74_Click(object sender, EventArgs e)
        {
        }

        private void label75_Click(object sender, EventArgs e)
        {
        }

        private void radioButton73_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox45_Enter(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel3_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox94_Enter(object sender, EventArgs e)
        {
        }

        private void radioButton214_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void groupBox96_Enter(object sender, EventArgs e)
        {
        }

        private void radioButton215_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox99_Enter(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel21_Paint(object sender, PaintEventArgs e)
        {
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void label43_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private void tableLayoutPanel10_Paint(object sender, PaintEventArgs e)
        {
        }

        private void groupBox60_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox97_Enter(object sender, EventArgs e)
        {
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void tableLayoutPanel9_Paint(object sender, PaintEventArgs e)
        {
        }

        private void fichierToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
        
        private void ValidPerso_Click(object sender, EventArgs e)
        {
            RadioButton[] listNok = {Persrb1NOk, Persrb2NOk, Persrb3NOk, Persrb4NOk};
            RadioButton[] l =
            {
                Persrb1Ok, Persrb1NOk, Persrb1Na, Persrb2Ok, Persrb2NOk, Persrb2Na, Persrb3Ok, Persrb3NOk,
                Persrb3Na, Persrb4Ok, Persrb4NOk, Persrb4Na
            };

            var insert = new InsertRepositories(ComPer, listNok, l, ValidPerso, ComPer.Text);
            insert.checkNokRb(err);

            if (insert.InsertData(dateStart, "Production HDD Pôle ADT", "Perso", desc, repo) > 0)
            {
                insert.insertPiloteFini(mat, navigationPage11.Caption);
            }
        }

        private void ValidAss1_Click(object sender, EventArgs e)
        {
            RadioButton[] listNok =
            {
                Ass1rb1NOk, Ass1rb2NOk, Ass1rb3NOk, Ass1rb4NOk, Ass1rb5NOk, Ass1rb6NOk, Ass1rb7NOk,
                Ass1rb8NOk, Ass1rb9NOk
            };
            RadioButton[] l =
            {
                Ass1rb1Ok, Ass1rb1NOk, Ass1rb1Na, Ass1rb2Ok, Ass1rb2NOk, Ass1rb2Na, Ass1rb3Ok, Ass1rb3NOk,
                Ass1rb3Na, Ass1rb4Ok, Ass1rb4NOk, Ass1rb4Na, Ass1rb5Ok, Ass1rb5NOk, Ass1rb5Na, Ass1rb6Ok, Ass1rb6NOk,
                Ass1rb6Na, Ass1rb7Ok, Ass1rb7NOk, Ass1rb7Na, Ass1rb8Ok, Ass1rb8NOk, Ass1rb8Na, Ass1rb9Ok, Ass1rb9NOk,
                Ass1rb9Na
            };
            var insert = new InsertRepositories(textBox4, listNok, l, ValidAss1, textBox4.Text);
            insert.checkNokRb(err);
            if (insert.InsertData(dateStart, "Production HDD Pôle ADT", "Assemblage 1", desc, repo) > 0)
            {
                insert.insertPiloteFini(mat, navigationPage1.Caption);
            }
        }

        private void ValidAss2_Click(object sender, EventArgs e)
        {
            RadioButton[] l =
            {
                Ass2rb1Ok, Ass2rb1NOk, Ass2rb1Na, Ass2rb2Ok, Ass2rb2NOk, Ass2rb2Na, Ass2rb3Ok, Ass2rb3NOk,
                Ass2rb3Na, Ass2rb4Ok, Ass2rb4NOk, Ass2rb4Na, Ass2rb5Ok, Ass2rb5NOk, Ass2rb5Na, Ass2rb6Ok, Ass2rb6NOk,
                Ass2rb6Na, Ass2rb7Ok, Ass2rb7NOk, Ass2rb7Na, Ass2rb8Ok, Ass2rb8NOk, Ass2rb8Na, Ass2rb9Ok, Ass2rb9NOk,
                Ass2rb9Na
            };
            RadioButton[] listNok =
            {
                Ass2rb1NOk, Ass2rb2NOk, Ass2rb3NOk, Ass2rb4NOk, Ass2rb5NOk, Ass2rb6NOk, Ass2rb7NOk,
                Ass2rb8NOk, Ass2rb9NOk
            };

            var insert = new InsertRepositories(Ass2Com, listNok, l, ValidAss2, Ass2Com.Text);
            insert.checkNokRb(err);
            if (insert.InsertData(dateStart, "Production HDD Pôle ADT", "Assemblage 2", desc, repo) > 0)
            {
                insert.insertPiloteFini(mat, navigationPage2.Caption);
            }
        }

        private void ValidPrepBt_Click(object sender, EventArgs e)
        {
            RadioButton[] l =
            {
                PrepBtrb1Ok, PrepBtrb1NOk, PrepBtrb1Na, PrepBtrb2Ok, PrepBtrb2NOk, PrepBtrb2Na,
                PrepBtrb3Ok, PrepBtrb3NOk, PrepBtrb3Na, PrepBtrb4Ok, PrepBtrb4NOk, PrepBtrb4Na, PrepBtrb5Ok,
                PrepBtrb5NOk, PrepBtrb5Na, PrepBtrb6Ok, PrepBtrb6NOk, PrepBtrb6Na, PrepBtrb7Ok, PrepBtrb7NOk,
                PrepBtrb7Na
            };
            RadioButton[] listNok =
            {
                PrepBtrb1NOk, PrepBtrb2NOk, PrepBtrb3NOk, PrepBtrb4NOk, PrepBtrb5NOk, PrepBtrb6NOk,
                PrepBtrb7NOk
            };

            var insert = new InsertRepositories(PrBtCom, listNok, l, ValidPrepBt, PrBtCom.Text);
            insert.checkNokRb(err);
            if (insert.InsertData(dateStart, "Production HDD Pôle ADT", "Préparation boite", desc, repo) > 0)
            {
                insert.insertPiloteFini(mat, navigationPage4.Caption);
            }
        }

        private void ValidContHDD_Click(object sender, EventArgs e)
        {
            RadioButton[] l =
            {
                ContHDDrb1Ok, ContHDDrb1NOk, ContHDDrb1Na, ContHDDrb2Ok, ContHDDrb2NOk, ContHDDrb2Na,
                ContHDDrb3Ok, ContHDDrb3NOk, ContHDDrb3Na, ContHDDrb4Ok, ContHDDrb4NOk, ContHDDrb4Na
            };

            RadioButton[] listNok = {ContHDDrb1NOk, ContHDDrb2NOk, ContHDDrb3NOk, ContHDDrb4NOk};

            var insert = new InsertRepositories(ConHDDCom, listNok, l, ValidContHDD, ConHDDCom.Text);
            insert.checkNokRb(err);
            if (insert.InsertData(dateStart, "Production HDD Pôle ADT", "Contrôle HDD", desc, repo) > 0)
            {
                insert.insertPiloteFini(mat, navigationPage5.Caption);
            }
        }

        private void ValidEmb_Click(object sender, EventArgs e)
        {
            RadioButton[] listNok =
            {
                Embrb1NOk, Embrb2NOk, Embrb3NOk, Embrb4NOk, Embrb5NOk, Embrb6NOk, Embrb7NOk,
                Embrb8NOk
            };
            RadioButton[] l =
            {
                Embrb1Ok, Embrb1NOk, Embrb1Na, Embrb2Ok, Embrb2NOk, Embrb2Na, Embrb3Ok, Embrb3NOk,
                Embrb3Na, Embrb4Ok, Embrb4NOk, Embrb4Na, Embrb5Ok, Embrb5NOk, Embrb5Na, Embrb6Ok, Embrb6NOk, Embrb6Na,
                Embrb7Ok, Embrb7NOk, Embrb7Na, Embrb8Ok, Embrb8NOk, Embrb8Na
            };

            var insert = new InsertRepositories(ComRmb, listNok, l, ValidEmb, ComRmb.Text);
            insert.checkNokRb(err);
            if (insert.InsertData(dateStart, "Production HDD Pôle ADT", "Emballage", desc, repo) > 0)
            {
                insert.insertPiloteFini(mat, navigationPage6.Caption);
            }
        }

        private void ValidPerc_Click(object sender, EventArgs e)
        {
            RadioButton[] l =
            {
                Percrb1Ok, Percrb1NOk, Percrb1Na, Percrb2Ok, Percrb2NOk, Percrb2Na, Percrb3Ok, Percrb3NOk,
                Percrb3Na, Percrb4Ok, Percrb4NOk, Percrb4Na
            };
            RadioButton[] listNok = {Percrb1NOk, Percrb2NOk, Percrb3NOk, Percrb4NOk};

            var insert = new InsertRepositories(ComPer, listNok, l, ValidPerc, ComPer.Text);
            insert.checkNokRb(err);
            if (insert.InsertData(dateStart, "Production HDD Pôle ADT", "Prérecette", desc, repo) > 0)
            {
                insert.insertPiloteFini(mat, navigationPage7.Caption);
            }
        }

        private void ValidPalet_Click(object sender, EventArgs e)
        {
            RadioButton[] l =
            {
                Paletrb1Ok, Paletrb1NOk, Paletrb1Na, Paletrb2Ok, Paletrb2NOk, Paletrb2Na, Paletrb3Ok,
                Paletrb3NOk, Paletrb3Na, Paletrb4Ok, Paletrb4NOk, Paletrb4Na, Paletrb5Ok, Paletrb5NOk, Paletrb5Na
            };
            RadioButton[] listNok = {Paletrb1NOk, Paletrb2NOk, Paletrb3NOk, Paletrb4NOk, Paletrb5NOk};

            var context = new AQLM2Entities();
            var repo = new ValOKdIntegrepositories(context);
            var desc = new OkDescriptRepositorie(context);
            //LigneRepositories lig = new LigneRepositories(context);

            var insert = new InsertRepositories(ComPale, listNok, l, ValidPalet, ComPale.Text);
            insert.checkNokRb(err);
            if (insert.InsertData(dateStart, "Production HDD Pôle ADT", "Palettisation", desc, repo) > 0)
            {
                insert.insertPiloteFini(mat, navigationPage8.Caption);
            }
        }

        private void ValidrecAQL_Click(object sender, EventArgs e)
        {
            RadioButton[] l =
            {
                RecAQLrb1Ok, RecAQLrb1NOk, RecAQLrb1Na, RecAQLrb2Ok, RecAQLrb2NOk, RecAQLrb2Na,
                RecAQLrb3Ok, RecAQLrb3NOk, RecAQLrb3Na, RecAQLrb4Ok, RecAQLrb4NOk, RecAQLrb4Na, RecAQLrb5Ok,
                RecAQLrb5NOk, RecAQLrb5Na, RecAQLrb6Ok, RecAQLrb6NOk, RecAQLrb6Na
            };
            RadioButton[] listNok = {RecAQLrb1NOk, RecAQLrb2NOk, RecAQLrb3NOk, RecAQLrb4NOk, RecAQLrb5NOk, RecAQLrb6NOk};

            var insert = new InsertRepositories(ComRecAql, listNok, l, ValidrecAQL, ComRecAql.Text);
            insert.checkNokRb(err);
            if (insert.InsertData(dateStart, "Production HDD Pôle ADT", "Recette AQL", desc, repo) > 0)
            {
                insert.insertPiloteFini(mat, navigationPage9.Caption);
            }
        }

        private void backMenuItem1_Click(object sender, EventArgs e)
        {
            Hide();
            var f = new Form5();
            f.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var pfi = new PiloteFiniRepositories(context);
            var poste =
                pfi.Get(p => p.date > dateStart && p.date < dateFinish && p.poste.Equals("CE"))
                    .Select(p => p.module)
                    .ToList();
            foreach (var d in poste)
            {
                switch (d)
                {
                    case "Recette AQL":
                        ValidrecAQL.Enabled = false;
                        break;
                    case "Palettisation":
                        ValidPalet.Enabled = false;
                        break;
                    case "Prérecette":
                        ValidPerc.Enabled = false;
                        break;
                    case "Emballage":
                        ValidEmb.Enabled = false;
                        break;
                    case "Contrôle HDD":
                        ValidContHDD.Enabled = false;
                        break;
                    case "Préparation boite":
                        ValidPrepBt.Enabled = false;
                        break;
                    case "Assemblage 2":
                        ValidAss2.Enabled = false;
                        break;
                    case "Assemblage 1":
                        ValidAss1.Enabled = false;
                        break;
                }
            }
        }
    }
}