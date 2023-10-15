using System;
using System.Net;

namespace CurrentMoonPhase
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = monthCalendar1.SelectionRange.Start;
            Moon.SetMoonPhase(date);
            string data = $"Phase: {Moon.phase}%" +
                $"\nPhase name: {Moon.phase_name}" +
                $"\nMoonrise: {Moon.moon_rise}" +
                $"\nMoonset: {Moon.moon_set}" +
                $"\nConstellation: {Moon.constellation}";
            label1.Text = data;
        }

        private  void Form1_Load(object sender, EventArgs e)
        {
            Moon.SetMoonPhase(DateTime.Now);
            string data = $"Phase: {Moon.phase}%"+
                $"\nPhase name: {Moon.phase_name}" +
                $"\nMoonrise: {Moon.moon_rise}" +
                $"\nMoonset: {Moon.moon_set}" +
                $"\nConstellation: {Moon.constellation}";
            label1.Text = data;
        }
    }
}