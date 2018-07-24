using Android.App;
using Android.Widget;
using Android.OS;
using System;
using System.Timers;

namespace Timer
{
    [Activity(Label = "Timer", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        System.Timers.Timer timer = null;
        TextView textView_Contador = null;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);

            textView_Contador = FindViewById<TextView>(Resource.Id.textView_Contador);

            var button_Iniciar = FindViewById<Button>(Resource.Id.button_Iniciar);
            var button_Cancelar = FindViewById<Button>(Resource.Id.button_Cancelar);
            var checkBox_StatusRelogio = FindViewById<CheckBox>(Resource.Id.checkBox_StatusRelogio);

            //ação do botão iniciar
            button_Iniciar.Click += delegate
            {
                //inicializa o timer
                timer = new System.Timers.Timer();

                //verifica se está ativo
                if(checkBox_StatusRelogio.Checked == true)
                {
                    //define o intervalo de 1 segundo
                    timer.Interval = 1000;

                    //exibe o timer?
                    timer.Elapsed += Timer_Elapsed;

                    //inicia o timer
                    timer.Start();
                }
            };

            button_Cancelar.Click += ButtonCancelar_Click;
        }

        private void ButtonCancelar_Click(object sender, EventArgs e)
        {
            Cancelar();
        }

        private void Cancelar()
        {
            timer.Enabled = false;
            timer.Dispose();
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            //data atual
            DateTime dateTime = DateTime.Now;

            //formato da data
            string formato = "dd/MM/yyyy HH:mm:ss";

            //define o texto do contador?
            RunOnUiThread(() => 
            {
                textView_Contador.Text = dateTime.ToString(formato);
            });
        }
    }
}

