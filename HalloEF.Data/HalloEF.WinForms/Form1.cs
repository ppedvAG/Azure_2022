using Bogus;
using HalloEF.Data;
using HalloEF.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace HalloEF.WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        EfContext _context = new();

        private void LadenButton_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _context.Mitarbeiter.Include(x => x.Abteilungen)
                                                           .Include(x => x.Kunden)
                                                           .Where(x => x.GebDatum.Year > 1000)
                                                           .ToList();
        }


        private void DemodatenButton_Click(object sender, EventArgs e)
        {
            var abtFaker = new Faker<Abteilungen>().RuleFor(x => x.Bezeichnung, x => x.Commerce.Department());
            var abts = abtFaker.Generate(10);

            var mitFaker = new Faker<Mitarbeiter>("de").UseSeed(12)
                                .RuleFor(x => x.Name, x => x.Person.FullName)
                                .RuleFor(x => x.Beruf, x => x.Name.JobArea())
                                .RuleFor(x => x.GebDatum, x => x.Date.Past(40))
                                .RuleFor(x => x.Abteilungen, x => new List<Abteilungen>() { x.PickRandom(abts), x.PickRandom(abts) });


            foreach (var mit in mitFaker.Generate(100))
            {
                _context.Add(mit);
            }
            _context.SaveChanges();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value is IEnumerable<Abteilungen> abts)
            {
                e.Value = string.Join(", ", abts.Select(x => x.Bezeichnung));
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _context.SaveChanges();
        }
    }
}