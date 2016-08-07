using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using PerformanceTest.OJService;

namespace PerformanceTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void test_Click(object sender, EventArgs e)
        {
            Random random = new Random(DateTime.Now.Millisecond);

            IOJService service = new OJServiceClient();

            for (int i = 1; i <= 100; i++)
            {
                string code;
                if (random.Next(0, 3) == 1)
                {
                    code =
                   "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b);\n printf(\"%d\\n\",a + b);\n return 0;\n }\n";
                }
                else if (random.Next(0, 3) == 0)
                {
                    code =
                   "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b);\n printf(\"%d\\n\",a + b + 1);\n return 0;\n }\n";
                }
                else
                {
                    code =
                   "#include<stdio.h>\n int main()\n { \nint a,b; \nscanf(\"%d%d\",&a,&b);\n printf(\"%d\\n\",a + b + 1);\n return 0\n \n";
                }

                WaitCallback submitCode = delegate
                {
                    service.SubmitCode(1, "C", code);
                };

                ThreadPool.QueueUserWorkItem(submitCode);

                progressBar1.Value = i;
            }
        }
    }
}
