﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Foundation;

namespace CloudCoin_SafeScan
{
    public static class ApplicationLogic
    {
        internal static void MainRun()
        {
           RAIDA.Instance.getEcho();
        }


		/*
                internal static void ScanSelected()
                {
         //           CloudCoinFile coinFile = null;
                    try
                    {
         //               string[] files = FileSystem.ChooseInputFile();
                        if (files != null)
                        {
        //                    coinFile = new CloudCoinFile(files);
                        }
                        else
                            return;
                    }
                    catch (FileNotFoundException fnfex)
                    {
         //               MessageBox.Show("File not found: " + fnfex.Message);
                    }

                    if(coinFile != null)
                    {
         //               MessageBoxResult mbres = MessageBox.Show("Would you like to change ownership and import money in Safe?\nChoosing \"No\" will simply scan coins without changing passwords.", "Change Ownership?", MessageBoxButton.YesNo);
         //               if(mbres == MessageBoxResult.Yes)
                        {
         //                   CheckCoinsWindow checkWin = new CheckCoinsWindow(coinFile.Coins);
         //                   RAIDA.Instance.Detect(coinFile.Coins, true);
         //                   checkWin.ShowDialog();

         //                   Safe.Instance?.Add(coinFile.Coins);
         //                   checkWin.Close();
         //                   Safe.Instance?.Show();
                        }
                        else
                        {
                            CheckCoinsWindow checkWin = new CheckCoinsWindow(coinFile.Coins);
                            RAIDA.Instance.Detect(coinFile.Coins, false);
                            checkWin.ShowDialog();


                            checkWin.Close();
                        }
                    }
                }

                internal static void DetectFracked()
                {
                    CoinStack fracked = new CoinStack(Safe.Instance.FrackedCoinsList);
                    CheckCoinsWindow checkWin = new CheckCoinsWindow(fracked);
                    RAIDA.Instance.Detect(fracked, false);
                    checkWin.ShowDialog();
                    Safe.Instance.Save();


                    checkWin.Close();
                }

                internal static void SafeSelected()
                {
                    Safe safe;
                    try { safe = Safe.Instance; }
                    catch (Exception ex)
                    {
                        safe = null;
                    }
                    if (safe != null)
                    {`
                        safe.Show();
                    }
                }
                internal static void PaySelected()
                {
                    Safe safe;
                    try { safe = Safe.Instance; }
                    catch (TypeInitializationException ex)
                    {
                        safe = null;
                    }
                    if (safe != null)
                    {
                        var howMuch = new HowMuchWindow();
                        howMuch.enterSumBox.Focus();
                        howMuch.Owner = MainWindow.Instance;
                        howMuch.ShowDialog();
                        if (howMuch.DialogResult == true)
                        {
                            int desiredSum = int.Parse(howMuch.enterSumBox.Text);
                            safe.SaveOutStack(desiredSum);
                            MessageBox.Show("Stack saved in Export dir\n");
                        }
                    }
                }

                 */

		internal async static Task FixSelected()
		{
			//FixProcessWindow fpw = new FixProcessWindow();
			int i = 0;
			foreach (CloudCoin coin in Safe.Instance.FrackedCoinsList)
			{
				await RAIDA.Instance.fixCoin(coin, i);
				i++;
			}
			//fpw.ShowDialog();
			Safe.Instance.onSafeContentChanged(new EventArgs());
			Safe.Instance.Save(); 
		}
    }
}
