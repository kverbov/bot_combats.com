﻿///////////////////////////////////////////////////////////////////////////////
//
// This file was automatically generated by RANOREX.
// Your custom recording code should go in this file.
// The designer will only add methods to this file, so your custom code won't be overwritten.
// http://www.ranorex.com
// 
///////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using WinForms = System.Windows.Forms;

using Ranorex;
using Ranorex.Core;
using Ranorex.Core.Testing;

namespace Test
{
    public partial class Fight
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.            
        }
        
        public bool DoFight(bool fightComplete)
        {
        	 Mouse.DefaultMoveTime = 300;
            Keyboard.DefaultKeyPressTime = 100;
            Delay.SpeedFactor = 1.0;
            

            //Init();       
 
//            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'БойцовскийКлуб1.Menu.SpanTagДумалНеОТомИУшелВСторон' at Center.", repo.БойцовскийКлуб1.Menu.SpanTagДумалНеОТомИУшелВСторонInfo, new RecordItemIndex(16));
//            repo.БойцовскийКлуб1.Menu.SpanTagДумалНеОТомИУшелВСторон.Click();
//            Delay.Milliseconds(200);
//            
//            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'БойцовскийКлуб1.Menu.SpanTagЗакашлялсяИЖестокийУвернулся' at Center.", repo.БойцовскийКлуб1.Menu.SpanTagЗакашлялсяИЖестокийУвернулсяInfo, new RecordItemIndex(17));
//            repo.БойцовскийКлуб1.Menu.SpanTagЗакашлялсяИЖестокийУвернулся.Click();
//            Delay.Milliseconds(200);
            
            if (fightComplete)
                return fightComplete;

            Random R = new Random();
            int att = R.Next(1, 5);
            int block = R.Next(1, 5);
            
			            
            //  если нет кнопки "Вперед" - выход
            bool continueFight=Func.WaitNextStep(7000,20000);
            if(!continueFight)
            {
            	Report.Log(ReportLevel.Info, "Mouse", "Конец боя.", null, new RecordItemIndex(0));
            	return true;
            }
            
		choose_misc:
            	
            #region Выбор дополненительные опции боя
			
            TdTag optRow=new TdTag( repo.БойцовскийКлуб1.Menu.OptionsRow);
			ButtonTag button=null;
			
			//	проверка если все элементы недоступны
            for(int i=0;i<optRow.Children.Count;i++)
            {
            	if(new ButtonTag(optRow.Children[i]).Class.ToString()!="UserBattleMethodDisabled")
            	{
            		button=new ButtonTag(optRow.Children[i]);
            		button.Click();
            		goto choose_misc;
            		
            	}
            	else if(i==optRow.Children.Count-1)
            		goto NoOption;
            		
            }
            
//            do{
//            	int optIndex = R.Next(1, optRow.Children.Count);
//            	button=new ButtonTag(optRow.Children[optIndex-1]);
//            }
//            while(button.Class.ToString()=="UserBattleMethodDisabled");
//            button.Click();
            
            #endregion
            	
		NoOption:
            
            if(!repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscTable.Visible)
            	//WinForms.MessageBox.Show("Таблица боя не видна!");
            	return DoFight(false);
            
            #region Атака

			
            try
            {
                switch (att)
                {
                    case 1:
                        // Удар в голову
            			Report.Log(ReportLevel.Info, "Mouse", "Удар в голову\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGifInfo, new RecordItemIndex(0));
            			repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif.Click();
            			Delay.Milliseconds(200);                      
                        break;
                    case 2:
                        // Удар в грудь
            			Report.Log(ReportLevel.Info, "Mouse", "Удар в грудь\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif1' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif1Info, new RecordItemIndex(1));
            			repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif1.Click();
            			Delay.Milliseconds(200);
                        break;
                    case 3:
                        // Удар в живот
			            Report.Log(ReportLevel.Info, "Mouse", "Удар в живот\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif2' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif2Info, new RecordItemIndex(3));
			            repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif2.Click();
			            Delay.Milliseconds(200);            
                        break;
                    case 4:
                        // Удар в пах
			            Report.Log(ReportLevel.Info, "Mouse", "Удар в пах\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif3' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif3Info, new RecordItemIndex(4));
			            repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif3.Click();
			            Delay.Milliseconds(200);
                        break;
                    case 5:
                        // Удар по ногам
			            Report.Log(ReportLevel.Info, "Mouse", "Удар по ногам\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif4' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif4Info, new RecordItemIndex(5));
			            repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif4.Click();
			            Delay.Milliseconds(200);            
                        break;
                }
            }
            catch (Exception e)
            {            	
            	return DoFight(false);
            }
            
            //	если двойное оружие
            if(doubleWeapon=="true")
            {
            	int att2 = R.Next(1, 5);
            	while(att2==att || att2==(att-1) || att2==(att+1))
            	{
            		att2 = R.Next(1, 5);
            	}            	
            	
            	TrTag tr=new TrTag( repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscTable.Children[att2]);
            	TdTag td=new TdTag(tr.Children[0]);
            	
            	try
            	{
            		td.Click();            	
            	}
	            catch (Exception e)
	            {
	            	//WinForms.MessageBox.Show(e.InnerException.Message);
	            	return DoFight(false);
	            }
            }
            #endregion

            #region Блок            
            
            switch (block)
            {
                case 1:
                    // Блок головы
		            Report.Log(ReportLevel.Info, "Mouse", "Блок головы\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif5' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif5Info, new RecordItemIndex(6));
		            repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif5.Click();
		            Delay.Milliseconds(200);            
                    break;
                case 2:
                    // Блок груди
            		Report.Log(ReportLevel.Info, "Mouse", "Блок груди\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif6' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif6Info, new RecordItemIndex(7));
            		repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif6.Click();
            		Delay.Milliseconds(200);            
                    break;
                case 3:
                    // Блок живота
		            Report.Log(ReportLevel.Info, "Mouse", "Блок живота\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif7' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif7Info, new RecordItemIndex(8));
		            repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif7.Click();
		            Delay.Milliseconds(200);
                    break;
                case 4:
                    // Блок пояса
		            Report.Log(ReportLevel.Info, "Mouse", "Блок пояса\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif8' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif8Info, new RecordItemIndex(9));
		            repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif8.Click();
		            Delay.Milliseconds(200);
                    break;
                case 5:
                    // Блок ног
		            Report.Log(ReportLevel.Info, "Mouse", "Блок ног\r\nMouse Left Click item 'БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif9' at Center.", repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif9Info, new RecordItemIndex(10));
		            repo.БойцовскийКлуб1.Menu.HttpImgCombatsRuIMiscRadioGif9.Click();
		            Delay.Milliseconds(200);
                    break;
            }

            #endregion

		if(!repo.БойцовскийКлуб1.Menu.Вперёд.Visible)
		{
			Report.Log(ReportLevel.Info, "Mouse", "'БойцовскийКлуб1.Menu.Вперёд' не видна.", repo.БойцовскийКлуб1.Menu.ВперёдInfo, new RecordItemIndex(15));
			return DoFight(false);
		}
			
			
		
			//	Вперед
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'БойцовскийКлуб1.Menu.Вперёд' at Center.", repo.БойцовскийКлуб1.Menu.ВперёдInfo, new RecordItemIndex(15));
            
            try
            {
            	repo.БойцовскийКлуб1.Menu.Вперёд.Click();
            }
            catch(Exception e)
            {
            		//WinForms.MessageBox.Show(e.InnerException.Message);
            		return DoFight(false);
            }
            
            Delay.Milliseconds(200);

            return DoFight(false);
            
        }

        public bool Validate_Вернуться()
        {
        	
        	//Adapter adVernutsa= Adapter.Create(Type.GetType(ButtonTag), repo.БойцовскийКлуб1.Menu.Вернуться);
            Report.Log(ReportLevel.Info, "Validation", "Validating AttributeEqual (Title='Вернуться') on item 'БойцовскийКлуб1.Menu.Вернуться'.", repo.БойцовскийКлуб1.Menu.ВернутьсяInfo);
            try
            {
            	
            }
            catch(Exception e)
            {
            	return false;
            }
            return true;            
        }

    }
}