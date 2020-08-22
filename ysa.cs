double[] wg1h1 = new double[4], wg1h2 = new double[4], wg2h1 = new double[4], wg2h2 = new double[4], wh1ç1 = new double[4], wh2ç1 = new double[4], qh1 = new double[4], qh2 = new double[4], qç1 = new double[4];
        double[] g1 = new double[4], g2 = new double[4], h1 = new double[4], h2 = new double[4], ç1 = new double[4], Hataç1 = new double[4], Hatah1 = new double[4], Hatah2 = new double[4];
        double alfa;
        double [] X1=new double[4],X2=new double[4],Y=new double[4];
//başlangıc değerlerinin atanması
            X1[0] = Convert.ToDouble(X1L0.Text); X2[0] = Convert.ToDouble(X2L0.Text); Y[0] = Convert.ToDouble(Y1txt.Text);
            X1[1] = Convert.ToDouble(X1L1.Text); X2[1] = Convert.ToDouble(X2L1.Text); Y[1] = Convert.ToDouble(Y2txt.Text);
            X1[2] = Convert.ToDouble(X1L2.Text); X2[2] = Convert.ToDouble(X2L2.Text); Y[2] = Convert.ToDouble(Y3txt.Text);
            X1[3] = Convert.ToDouble(X1L3.Text); X2[3] = Convert.ToDouble(X2L3.Text); Y[3] = Convert.ToDouble(Y4txt.Text);
            alfa=Convert.ToDouble(OgrenmeKatsayiText.Text);
           
            wg1h1[0] = Convert.ToDouble(WG1H1txt.Text); wg1h2[0] = Convert.ToDouble(WG1H2txt.Text);
            wg2h1[0] = Convert.ToDouble(WG2H1txt.Text); wg2h2[0] = Convert.ToDouble(WG2H2txt.Text);
            wh1c1[0] = Convert.ToDouble(WH1c1txt.Text); wh2c1[0] = Convert.ToDouble(WH2c1txt.Text);
            qh1[0] = Convert.ToDouble(QH2txt.Text); qh2[0] = Convert.ToDouble(QH1txt.Text);   qc1[0] = Convert.ToDouble(qc1txt.Text);
            
             wg1h1[1] = Convert.ToDouble(WG1H1txt.Text); wg1h2[1] = Convert.ToDouble(WG1H2txt.Text);
            wg2h1[1] = Convert.ToDouble(WG2H1txt.Text); wg2h2[1] = Convert.ToDouble(WG2H2txt.Text);
            wh1c1[1] = Convert.ToDouble(WH1c1txt.Text); wh2c1[1] = Convert.ToDouble(WH2c1txt.Text);
            qh1[1] = Convert.ToDouble(QH2txt.Text); qh2[1] = Convert.ToDouble(QH1txt.Text);   qc1[1] = Convert.ToDouble(qc1txt.Text);
            
             wg1h1[2] = Convert.ToDouble(WG1H1txt.Text); wg1h2[2] = Convert.ToDouble(WG1H2txt.Text);
            wg2h1[2] = Convert.ToDouble(WG2H1txt.Text); wg2h2[2] = Convert.ToDouble(WG2H2txt.Text);
            wh1c1[2] = Convert.ToDouble(WH1c1txt.Text); wh2c1[2] = Convert.ToDouble(WH2c1txt.Text);
            qh1[2] = Convert.ToDouble(QH2txt.Text); qh2[2] = Convert.ToDouble(QH1txt.Text); qc1[2] = Convert.ToDouble(qc1txt.Text);
            
             wg1h1[3] = Convert.ToDouble(WG1H1txt.Text); wg1h2[3] = Convert.ToDouble(WG1H2txt.Text);
            wg2h1[3] = Convert.ToDouble(WG2H1txt.Text); wg2h2[3] = Convert.ToDouble(WG2H2txt.Text);
            wh1c1[3] = Convert.ToDouble(WH1c1txt.Text); wh2c1[3] = Convert.ToDouble(WH2c1txt.Text);
            qh1[3] = Convert.ToDouble(QH2txt.Text); qh2[3] = Convert.ToDouble(QH1txt.Text); qc1[3] = Convert.ToDouble(qc1txt.Text);
            
            richTextBox1.Text = "";

            int a, i;
            for ( a = 0; a < Convert.ToDouble(iterasyonsayisitxt.Text); a++)
            {
                richTextBox1.AppendText("iterasyon :"+a+"");

                for ( i = 0; i < 4; i++)
                {
                    h1[i] = X1[i] * (wg1h1[i]) + X2[i] * (wg2h1[i]) + qh1[i];
                    h1[i] = 1 / (1 + (System.Math.Exp(-h1[i])));
                    h2[i] = g1[i] * (wg2h1[i]) + g2[i] * (wg2h2[i]) + qh2[i];
                    h2[i] = 1 / (1 + (System.Math.Exp(-h2[i])));
                    c1[i] = (h1[i] * (wh1c1[i])) + h2[i] * (wh2c1[i]) + qc1[i];
                    c1[i] = 1 / (1 + (System.Math.Exp(-c1[i])));


                    Hatac1[i] = c1[i] * (1 - c1[i]) * ((Y[i] - c1[i]));
                    // ((Y[0] - c1) + (coklu cıkış))  Birden fazla cıkış carsa işlemleri yapılıp toplanır
                    Hatah1[i] = h1[i] * (1 - h1[i]) * ((Hatac1[i] * wh1c1[i])+0);
                    Hatah2[i] = h2[i] * (1 - h2[i]) * ((Hatac1[i] * wh2c1[i])+0);
                
                    //Yeni Ağırlık  ve bias değerleri
                    wh1c1[i] = wh1c1[i] + (alfa * Hatac1[i] * h1[i]);
                    wh2c1[i] = wh2c1[i] + (alfa * Hatac1[i] * h2[i]);
                    wg1h1[i] = wh1c1[i] + (alfa * Hatah1[i] * X1[i]);
                    wg1h2[i] = wg1h2[i] + (alfa * Hatah2[i] * X1[i]);
                    wg2h1[i] = wg2h1[i] + (alfa * Hatah1[i] * X2[i]);
                    wg2h2[i] = wg2h2[i] + (alfa * Hatah2[i] * X2[i]);
                    qc1[i] = qc1[i] + (alfa * Hatac1[i]);
                    qh1[i] = qh1[i] + (alfa * Hatah1[i]);
                    qh2[i] = qh2[i] + (alfa * Hatah2[i]);

                    X1[i] = qh1[i]; X2[i] = qh2[i];

                    richTextBox1.AppendText(" \nwh1c1 :" + wh1c1[i] + "\n wh2c1 :" + wh2c1[i] + " \n wg1h1 : " + wg1h1[i] + "\n\n");
                    richTextBox1.AppendText(" \n wg1h2 :" + wg1h2[i] + "\n wg2h1 :" + wg2h1[i] + " \n  wg2h2 : " + wg2h2[i] + "\n\n");
                    richTextBox1.AppendText(" \n qc1 :" + qc1[i] + "\n qh1 :" + qh1[i] + " \n qh2 : " + qh2[i] + "\n\n");
                richTextBox1.AppendText("\nAdım: "+i+" \nG1 :"+X1[i]+"\n G2 :"+X2[i]+" \nSonuc : "+Y[i]+"\n\n");
                }

                             
            }
