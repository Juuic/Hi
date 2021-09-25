/////////////////////////////////////////////////////////////////////////
//                                                                     //
//      After Junk Code Obfuscating - C/C++ Example Source Code        //
//                                                                     //
/////////////////////////////////////////////////////////////////////////

void read_data(void* data, int bits_of_data, unsigned char* bit_stream,
  unsigned long &bit_offset)
{
    // junk instruction begin
    __asm
    {
        jz _P01
            jnz _P01
            _emit 0e8h
      _P01:
    }
    // junk instruction end

    int i;

// junk instruction begin
__asm
{
    jz _P01
            jnz _P01
            _emit 0e9h
      _P01:
    }
// junk instruction end

int n;

// junk instruction begin
__asm
{
    clc
    jnb   _P01
    _emit 0e8h
    _emit 0e8h
_P01:
    }
// junk instruction end

while (bits_of_data > 0)
{
    // junk instruction begin
    __asm
      {
        jz _P01
              jnz _P01
              _emit 09ah
              _emit 0e8h
        _P01:
      }
    // junk instruction end

    n = bits_of_data > 8 ? 8 : bits_of_data;

    // junk instruction begin
    __asm
      {
        clc
        jnb   _P01
        _emit 0e8h
        _emit $e8h
  _P01:
      }
    // junk instruction end

    *(unsigned char*)data = 0;

    // junk instruction begin
    __asm
      {
        jl _P01
        _P02: jmp _P03
              _emit 0e8h
        _P01: jz _P02
        _P03:
      }
    // junk instruction end

    for (i = 0; i < n; i++)
    {
        if (read_bit(bit_stream, bit_offset))
        {
            (*(unsigned char*)data) |= (1 << i);
}

// junk instruction begin
__asm
{
    jle _P01
                jg _P01
                _emit 0e8h
          _P01:
        }
// junk instruction end

bit_offset++;
      }
  
      // junk instruction begin
      __asm
{
    clc
    jnb   _P01
    _emit 0e8h
    _emit 0e8h
_P01:
      }
// junk instruction end

data = ((unsigned char*)data) +1;

// junk instruction begin
__asm
{
    jc _P01
              jnc _P01
              _emit 0e8h
        _P01:
      }
// junk instruction end

bits_of_data -= n;

// junk instruction begin
__asm
{
    jz _P01
              jnz _P01
              _emit 0e8h
        _P01:
      }
      // junk instruction end
    }
  }


//SimpleLoader by Wilson, https://github.com/WilsonPublic/SimpleLoader [Open Source Cheat Loader]
//This is very noob friendly and can easily be adapted, this has no form of protection against cracking so please come up with your own ideas on how to prevent cracking
//I recommend using Dot Net Reactor to protect your programs

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ManualMapInjection.Injection;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string HWID;

        private void Form1_Load(object sender, EventArgs e)
        {
            HWID = System.Security.Principal.WindowsIdentity.GetCurrent().User.Value; //Changing the variable "HWID (String)" to the WindowsIdentity Value, you can use any other forms of HWID, you can even use MAC/IP (Not recommended)
            textBox1.Text = HWID;
            textBox1.ReadOnly = true;
            checkonline();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkonline();
            WebClient wb = new WebClient();
            string HWIDLIST = wb.DownloadString("https://raw.githubusercontent.com/Juuic/Csgo-codes/main/License%20key"); //Replace "HWID List URL" with your own URL to a RAW text (txt) file with all your wanted HWIDs [Example: http://myurl.com/HWID.txt]
            if (HWIDLIST.Contains(textBox1.Text)) //You can add a "!" before the "HWIDLIST" and after the "if (" to make it into a blacklist HWID system instead of a whitelist HWID system
            {
                string mainpath = "C:\\Windows\\random.dll"; //You can change the path to wherever you want but just remember to use "\\" instead of just one "\"
                wb.DownloadFile("https://github.com/Juuic/Csgo-codes/blob/main/Trigger.dll?raw=true", mainpath); //Replace "DLL URL" with the URL to directly download your DLL [Example: http://myurl.com/MYDLL.dll]
                var name = "csgo"; //Replace "csgo" with any exe you want [Example: For Team Fortress 2 you would replace it with "hl2"]
                var target = Process.GetProcessesByName(name).FirstOrDefault();
                var path = mainpath;
                var file = File.ReadAllBytes(path);

                //Checking if the DLL isn't found
                if (!File.Exists(path))
                {
                    MessageBox.Show("Error: DLL not found");
                    return;
                }
                
                //Injection, just leave this alone if you are a beginner
                var injector = new ManualMapInjector(target) { AsyncInjection = true };
                label2.Text = $"hmodule = 0x{injector.Inject(file).ToInt64():x8}";
                
                if (System.IO.File.Exists(mainpath)) //Checking if the DLL exists
                {
                    System.IO.File.Delete(mainpath); //Deleting the DLL
                }
            }
            else
            {
                MessageBox.Show("HWID Incorrect");
            }
        }

        private void checkonline()
        {
            //Checking if the user can get a response from "https://google.com/"
            try
            {
                using (var client = new WebClient())
                {
                    using (client.OpenRead("https://google.com/"))
                    {
                        label1.ForeColor = Color.Green;
                        label1.Text = ("Online");
                    }
                }
            }
            catch
            {
                //If it does not get a response (This means the user is offline or google is down for some reason) it will Exit the application, you can stop this by removing "Application.Exit();"
                label1.ForeColor = Color.Red;
                label1.Text = ("Offline");
                Application.Exit();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(HWID);
            button2.Enabled = false;
            button2.Text = "Copied";
        }
    }
}


