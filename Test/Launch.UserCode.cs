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
    public partial class Launch
    {
        /// <summary>
        /// This method gets called right after the recording has been started.
        /// It can be used to execute recording specific initialization code.
        /// </summary>
        private void Init()
        {
            // Your recording specific initialization code goes here.
        }
        
        /// <summary>
        /// Ожидаем начала боя
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public void WaitFight(int min, int max)
        {
        	Report.Log(ReportLevel.Info, "Keyboard", "Ожидаем начала боя ");
        	while(true)
        	{
        		Func.Wait( min,max);
        		if(Func.Validate_Вперёд())
        		{
        			break;
        		}
        		else
        		{
        			Report.Log(ReportLevel.Info, "Validation", "Ожидаем начала боя. Кнопка 'Вперед ' не появилась. Жмем 'F5'", repo.БойцовскийКлуб1.Menu.ВперёдInfo);
        			Keyboard.Press("{F5}");
        		}
        	}
        	Report.Log(ReportLevel.Info, "Validation", "Появилась  кнопка 'Вперед '. Бой начался.", repo.БойцовскийКлуб1.Menu.ВперёдInfo);
        
        }

        /// <summary>
        /// Ожидаем начала боя
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        public bool WaitGPFight(int min, int max, int end )
        {
        	//	проверка входных данных
        	if(max>end)
        	{
        		Report.Log(ReportLevel.Info, "WaitGPFight. Некорректные входные данные  max>end");
        		WinForms.MessageBox.Show("WaitGPFight. Некорректные входные данные  max>end");
        			
        	}
        	
        	System.DateTime start=System.DateTime.Now;
        	Report.Log(ReportLevel.Info, "Keyboard", "Ожидаем начала группового боя ");
        	while(true)
        	{
        		
        		Func.Wait( min,max);
        		if(Func.Validate_Вперёд())
        		{
        			Report.Log(ReportLevel.Info, "Validation", "Появилась  кнопка 'Вперед '. Бой начался.", repo.БойцовскийКлуб1.Menu.ВперёдInfo);
        			return true;        			
        		}
        		else
        		{
        			TimeSpan interval=System.DateTime.Now-start;
        			if(interval.TotalMilliseconds>end)
        			{
        				Report.Log(ReportLevel.Info, "Validation", "Ожидание начала группового боя. Время ожидания истекло "+ end.ToString()+" мс", repo.БойцовскийКлуб1.Menu.ВперёдInfo);
        				return false;
        			}
        				
        			Report.Log(ReportLevel.Info, "Validation", "Ожидаем начала боя. Кнопка 'Вперед ' не появилась. Жмем 'F5'", repo.БойцовскийКлуб1.Menu.ВперёдInfo);
        			Keyboard.Press("{F5}");
        		}
        	}
        	
        
        }

        
        
        public void Mouse_Click_Open()
        {
            
        }

        public void Validate_Open()
        {
            Report.Log(ReportLevel.Info, "Validation", "подать заявку\r\nValidating Exists on item 'БойцовскийКлуб1.Menu.Open'.", repo.БойцовскийКлуб1.Menu.OpenInfo);
            Validate.Exists(repo.БойцовскийКлуб1.Menu.OpenInfo);
        }

        
        public bool MenuSelect(string itemName)
        {
        	SpanTag menu=repo.БойцовскийКлуб1.Menu.Меню;
        	for (int i=0;i<menu.Children.Count;i++)
        	{
        		ATag item=menu.Children[i].As<ATag>();
        		if(item.InnerText.Contains(itemName))
        		{
        			Report.Log(ReportLevel.Info, "Найден пункт меню '"+item.InnerText+"', содержащий строку '"+itemName+"'. Щелкаем его.");
        			Func.WaitElementAppear(item);
        			Report.Log(ReportLevel.Info, "Щелкаем на "+item.ToString());
        			item.PerformClick(); 
        			return true;
        		}
        		
        	}
        	
        	Report.Log(ReportLevel.Info, "Не найден пункт меню '"+itemName+"'");
        	return false;
        	
        
        }
        
        /// <summary>
        /// снять обмундирование 
        /// </summary>
        /// <returns>true - без ошибок </returns>
        public void UndressPerson()
        {
        	MenuSelect("Инвентарь");
        	InputTag input=repo.БойцовскийКлуб1.Menu.Snatvso;
        	if(Func.WaitElementAppear(input))
        		Func.ClickElement(input);
        	else
        		Report.Log(ReportLevel.Info, "Кнопка "+input.ToString()+" не найдена!");
        	
        	Func.WaitElementAppear(repo.БойцовскийКлуб1.Menu.Вернуться);
        	Func.ClickElement(repo.БойцовскийКлуб1.Menu.Вернуться);
        	   	
        }
        
        public void DressUpPerson()
        {
        	MenuSelect("Инвентарь");
        	ATag input=repo.БойцовскийКлуб1.Menu.НадетьМойКомплект;
        	if(Func.WaitElementAppear(input))
        		Func.ClickElement(input);
        	else
        		Report.Log(ReportLevel.Info, "Кнопка "+input.ToString()+" не найдена!");
        	
        	Func.WaitElementAppear(repo.БойцовскийКлуб1.Menu.Вернуться);
        	Func.ClickElement(repo.БойцовскийКлуб1.Menu.Вернуться);
        	        	   	
        }
        
        public void RepairPerson()
        {
        	Report.Log(ReportLevel.Info, "Ремонт. Идем на централную площадь. ");
        	Func.WaitElementAppear(repo.Rooms.Центральная_площадь_из_зала_воинов);
        	Func.ClickElement(repo.Rooms.Центральная_площадь_из_зала_воинов);
        	Delay.Seconds(5);
        	while(!repo.Rooms.Зал_воиновInfo.Exists(5000))
        		Func.ClickElement(repo.Rooms.Центральная_площадь_из_зала_воинов);
        		
        	
        	Report.Log(ReportLevel.Info, "Ремонт. Идем в ремонтную мастерскую. ");
        	Func.WaitElementAppear(repo.Rooms.Ремонтная_мастерская);
        	Func.ClickElement(repo.Rooms.Ремонтная_мастерская);
        	Delay.Seconds(5);
        	while(!repo.RemMasterskaya.RepairWelcomeScreenInfo.Exists(5000))
        		Func.ClickElement(repo.Rooms.Ремонтная_мастерская);
        	
        	Report.Log(ReportLevel.Info, "Ремонт. Щелкаем на мужичка. ");
        	Func.WaitElementAppear(repo.RemMasterskaya.RepairWelcomeScreen);
        	Func.ClickElement(repo.RemMasterskaya.RepairWelcomeScreen);
        	Delay.Seconds(5);
        	while(!repo.RemMasterskaya.ATagДаЕстьНекоторыеПроблемыInfo.Exists(5000))
        		Func.ClickElement(repo.RemMasterskaya.RepairWelcomeScreen);
        	
        	Report.Log(ReportLevel.Info, "Ремонт. Щелкаем ATagДаЕстьНекоторыеПроблемы ");
        	Func.WaitElementAppear(repo.RemMasterskaya.ATagДаЕстьНекоторыеПроблемы);
        	Func.ClickElement(repo.RemMasterskaya.ATagДаЕстьНекоторыеПроблемы);
        	Delay.Seconds(5);
        	while(!repo.RemMasterskaya.RepairListTBodyInfo.Exists(5000))
        		Func.ClickElement(repo.RemMasterskaya.ATagДаЕстьНекоторыеПроблемы);
        	
        	RepairWeapon(0);
        	
        	Report.Log(ReportLevel.Info, "Ремонт. Выход на центр плозадь из рем мастерской");
        	Func.WaitElementAppear(repo.RemMasterskaya.Центральная_площад);
        	Func.ClickElement(repo.RemMasterskaya.Центральная_площад);
        	while(!repo.Rooms.Зал_воиновInfo.Exists(5000))
        		Func.ClickElement(repo.RemMasterskaya.Центральная_площад);
        		
        	Report.Log(ReportLevel.Info, "Ремонт. Вход в зал воинов");
        	Func.WaitElementAppear(repo.Rooms.Зал_воинов);
        	Func.ClickElement(repo.Rooms.Зал_воинов);
        	Delay.Seconds(15);
        	
        	while(!repo.БойцовскийКлуб1.Menu.Combats1Info.Exists(5000))
        	{
        		Report.Log(ReportLevel.Info, "Ремонт. Повторный вход в зал воинов");
        		Func.ClickElement(repo.Rooms.Зал_воинов);
        	}
        	   	
        }
        
         public bool RepairWeapon(int index)
        {
         	TBodyTag table= repo.RemMasterskaya.RepairListTBody;
        	
        	//	если конец таблицы
        	if(table.Children.Count==index)
        		return true;
        	        	
        	//	проходим по текущей строке 
        	TrTag row=new TrTag(table.Children[index]);
        	
			//	ячейки строки
        	TdTag leftCell=new TdTag(row.Children[0]);
        	TdTag rightCell=new TdTag(row.Children[1]);
        	            
            #region		Проверка параметра "долговечность"
            
            bool badWeapon=false;
            
            string[] text=rightCell.InnerText.Split(' ');
            for (int i =0;i<text.Length;i++)
            {
            	if(text[i].Contains("Долговечность"))
            	{
            		string number=text[i+1];
            		int slashIndex=  number.IndexOf("/");
            		
            		if(slashIndex==-1)
            		{
            			Report.Log(ReportLevel.Info, "Ремонт. Найдено сломанное оружие \n"+text);
            			badWeapon=true;
            		}
            			
            		break;
//            		int leftNum=int.Parse( number.Substring(0,slashIndex));
//            		int rightNum=int.Parse( number.Substring(slashIndex+1,number.Length-1-slashIndex-1));            		
            	}
            }
            
            #endregion        	   
            
            #region	Ремонт
            
            if(badWeapon )
            {
            	Report.Log(ReportLevel.Info, "Ремонт. Ремонтируем. ");
            	SmallTag sm= leftCell.FindChild<SmallTag>();
            	ATag href=new ATag(sm.Children[sm.Children.Count-1]);
            	Func.ClickElement(href);
            		
				//	оружие исчезает из таблицы после починки
            	index-=1;
            	
            	
            }
            	
            #endregion
                    	
        	//	рекурсивный вызов с увеличением индекса
        	return RepairWeapon(index+1);
        }

        
        /// <summary>
        ///	Поиск пустого слота в снаряжении персонажа.
        /// </summary>
        /// <returns>Есть есть пустой слот - true</returns>
        public bool IsEmptySlot()
        {
        	
        	//	проходим по вертикали по каждому слоту в левой и правой руке и ищем пустой слот
        	for(int i=0;i<4;i++)
        	{        		
        		TrTag trLeft=new TrTag( repo.БойцовскийКлуб1.Menu.WeaponTbodyLeft.Children[i]);
        		TrTag trRight=new TrTag(repo.БойцовскийКлуб1.Menu.WeaponTbodyRight.Children[i+3]);
        		TdTag tdLeft=new TdTag(trLeft.Children[0]);
        		TdTag tdRight=new TdTag(trRight.Children[0]);
        		
        		//	если слот оружие в критическом состоянии значит индекс =1 - выбираем последний children 
        		ImgTag leftCurrentSlot=new ImgTag( tdLeft.Children[tdLeft.Children.Count-1]);
        		ImgTag rightCurrentSlot=new ImgTag( tdRight.Children[tdRight.Children.Count-1]);
        		
        		//	проверяем свойство картинки 'Title' 
        		if(leftCurrentSlot.Title.Contains("Пустой слот") || rightCurrentSlot.Title.Contains("Пустой слот"))
        		{
        			Report.Log(ReportLevel.Info, "Проверка на пустой слот персонажа. Найден пустой слот № "+i.ToString()+". Необходимо снять все доспехи.");
        			
        			//	проверка если второе оружие отсутствует
        			if(i==1 && rightCurrentSlot.Title.Contains("Пустой слот"))
        			{
        				Fight.Instance.doubleWeapon="false";
        				Report.Log(ReportLevel.Info, "Второе оружие отсутствует. Переключаем режим боя в одно оружие.");
        			}
        			return true;
        		}
        	}
        	   
        	Report.Log(ReportLevel.Info, "Проверка на пустой слот персонажа. Все слоты заняты, персонаж полностью вооружен. ");
        	return false;        	
        }
        
                
        public void ChooseFight(  )
        {
        	repo.БойцовскийКлуб1.Self.Browser.Activate();        	
        	repo.БойцовскийКлуб1.Self.Browser.PressKeys("{F5}");
        	Validate.Exists(repo.БойцовскийКлуб1.Menu.Combats1);
        	if(Func.WaitElementAppear( repo.БойцовскийКлуб1.Menu.Combats1))
        	{
        		//	если есть пустой слот у персонажа 
        		if( IsEmptySlot())
        		{
        			if(undressIfEmptySlot=="true")
        			{
        				UndressPerson();        				
        			}
        			if(repairIfEmptySlot=="true")
        			{
        				RepairPerson();        				
        			}
        			DressUpPerson();
        			//fightType=defaultFightType;        			
        		}
        		Report.Log(ReportLevel.Info, "Validation", "Validating Exists on item 'БойцовскийКлуб1.Menu.Combats1'.", repo.БойцовскийКлуб1.Menu.Combats1Info, new RecordItemIndex(5));
            	Validate.Exists(repo.БойцовскийКлуб1.Menu.Combats1Info);
            	Delay.Milliseconds(100);
            	Func.WaitElementAppear(repo.БойцовскийКлуб1.Menu.Combats1);
            	Func.ClickElement(repo.БойцовскийКлуб1.Menu.Combats1);
            	
	            Report.Log(ReportLevel.Info, "Validation", "Нажали 'БойцовскийКлуб1.Menu.Combats'.", repo.БойцовскийКлуб1.Menu.ATag1На1Info, new RecordItemIndex(7));
        	}
        	else
        	{
        		Report.Log(ReportLevel.Info, "Mouse", "Не найден 'БойцовскийКлуб1.Menu.Combats'. Перегружаем страницу.", repo.БойцовскийКлуб1.Menu.OpenInfo);
        		Keyboard.Press("{F5}");
        		ChooseFight();        		
        	}
            
            // выбор типа боя
            Report.Log(ReportLevel.Info, "Keyboard", "Подаем заявку на бой. Выбор типа боя");
            Validate.Exists(repo.БойцовскийКлуб1.Menu.ATag1На1Info);
            Delay.Milliseconds(0);
            
            //	тип боя 1:"1на1" или 2:"Групповые" или 2к:"групповые кулачные"
            if(fightType=="1")
            {
	            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'БойцовскийКлуб1.Menu.ATag1На1' at Center.", repo.БойцовскийКлуб1.Menu.ATag1На1Info, new RecordItemIndex(8));
	            Func.ClickElement( repo.БойцовскийКлуб1.Menu.ATag1На1);
	            Delay.Milliseconds(200);            
	            
	            Report.Log(ReportLevel.Info, "Validation", "подать заявку\r\nValidating Exists on item 'БойцовскийКлуб1.Menu.Open'.", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(9));
	            Validate.Exists(repo.БойцовскийКлуб1.Menu.OpenInfo);
	            Delay.Milliseconds(100);
	            if(repo.БойцовскийКлуб1.Menu.Open.Visible)
	            {
		            Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'БойцовскийКлуб1.Menu.Open' at Center.", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(10));
		            Func.WaitElementAppear(repo.БойцовскийКлуб1.Menu.Open);
		            Func.ClickElement(repo.БойцовскийКлуб1.Menu.Open);
		            Delay.Milliseconds(200);
	            }
	            else
	        	{
	            	Report.Log(ReportLevel.Info, "Mouse", "Не найден 'БойцовскийКлуб1.Menu.Open'. Перегружаем страницу.", repo.БойцовскийКлуб1.Menu.OpenInfo);
	        		Keyboard.Press("{F5}");
	        		ChooseFight();        		
	        	}
            }
            else if(fightType=="2")
            {
            	Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'БойцовскийКлуб1.Menu.ATag1На1' at Center.", repo.БойцовскийКлуб1.Menu.ATag1На1Info, new RecordItemIndex(8));
	            Func.ClickElement(repo.БойцовскийКлуб1.Menu.Групповые);
	            Delay.Milliseconds(200);            
	            
	            Report.Log(ReportLevel.Info, "Validation", "подать заявку в групповые бои\r\nValidating Exists on item 'БойцовскийКлуб1.Menu.Open'.", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(9));
	            Validate.Exists(repo.БойцовскийКлуб1.Menu.OpenGroup);
	            Delay.Milliseconds(500);
	            if(repo.БойцовскийКлуб1.Menu.OpenGroup.Visible)
	            {
		            Report.Log(ReportLevel.Info, "Mouse", "Появилась кнопка 'Подать новую заявку'. Жмем.", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(10));
		            Func.ClickElement(repo.БойцовскийКлуб1.Menu.OpenGroup);
		            Delay.Milliseconds(500);
		            Report.Log(ReportLevel.Info, "Mouse", "Выбираем таймаут боя", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(10));
		            repo.БойцовскийКлуб1.Menu.Timeout.PressKeys(timeoutFight);
		            Report.Log(ReportLevel.Info, "Mouse", "Выбираем максимальное число бойцов с одной стороны", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(10));
		            repo.БойцовскийКлуб1.Menu.Nlogin1.Value=fighterCount;
		            SelectTag sTag=new SelectTag(repo.БойцовскийКлуб1.Menu.Levellogin1);
		            sTag.TagValue=fightLevelIndex;
		            repo.БойцовскийКлуб1.Menu.Nlogin2.Value=fighterCount;
		            sTag=new SelectTag(repo.БойцовскийКлуб1.Menu.Levellogin2);
		            sTag.TagValue=fightLevelIndex;
		            Func.WaitElementAppear(repo.БойцовскийКлуб1.Menu.Open1);
		            Func.ClickElement(repo.БойцовскийКлуб1.Menu.Open1);
		            
	            }
	            else
	        	{
	            	Report.Log(ReportLevel.Info, "Mouse", "Не найден 'БойцовскийКлуб1.Menu.OpenGroup'. Перегружаем страницу.", repo.БойцовскийКлуб1.Menu.OpenGroupInfo);
	        		Keyboard.Press("{F5}");
	        		ChooseFight();        		
	        	}
            	
            }
             else if(fightType=="2k")
            {
            	Report.Log(ReportLevel.Info, "Mouse", "Mouse Left Click item 'БойцовскийКлуб1.Menu.ATag1На1' at Center.", repo.БойцовскийКлуб1.Menu.ATag1На1Info, new RecordItemIndex(8));
	            Func.ClickElement(repo.БойцовскийКлуб1.Menu.Групповые);
	            Delay.Milliseconds(200);            
	            
	            Report.Log(ReportLevel.Info, "Validation", "подать заявку в групповые кулачные бои\r\nValidating Exists on item 'БойцовскийКлуб1.Menu.Open'.", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(9));
	            Validate.Exists(repo.БойцовскийКлуб1.Menu.OpenGroup);
	            Delay.Milliseconds(500);
	            if(repo.БойцовскийКлуб1.Menu.OpenGroup.Visible)
	            {
		            Report.Log(ReportLevel.Info, "Mouse", "Появилась кнопка 'Подать новую заявку'. Жмем.", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(10));
		            Func.ClickElement(repo.БойцовскийКлуб1.Menu.OpenGroup);
		            Delay.Milliseconds(500);
		            Report.Log(ReportLevel.Info, "Mouse", "Выбираем таймаут боя", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(10));
		            repo.БойцовскийКлуб1.Menu.Timeout.PressKeys(timeoutFight);
		            Report.Log(ReportLevel.Info, "Mouse", "Выбираем максимальное число бойцов с одной стороны", repo.БойцовскийКлуб1.Menu.OpenInfo, new RecordItemIndex(10));
		            repo.БойцовскийКлуб1.Menu.Nlogin1.Value=fighterCount;
		            SelectTag sTag=new SelectTag(repo.БойцовскийКлуб1.Menu.Levellogin1);
		            Report.Log(ReportLevel.Info, "Mouse", "Выбираем уровень противников");
		            sTag.TagValue=fightLevelIndex;
		            Report.Log(ReportLevel.Info, "Mouse", "Выбираем максимальное число бойцов с другой стороны");
		            repo.БойцовскийКлуб1.Menu.Nlogin2.Value=fighterCount;
		            sTag=new SelectTag(repo.БойцовскийКлуб1.Menu.Levellogin2);
		            sTag.TagValue=fightLevelIndex;
		             Report.Log(ReportLevel.Info, "Mouse", "Выбираем тип-  кулачный бой " );
		            InputTag kulachFight=repo.БойцовскийКлуб1.Menu.КулачныйCheckButton;
		            Func.ClickElement(kulachFight);
		            Func.WaitElementAppear(repo.БойцовскийКлуб1.Menu.Open1);
		            Func.ClickElement(repo.БойцовскийКлуб1.Menu.Open1);
		            
	            }
	            else
	        	{
	            	Report.Log(ReportLevel.Info, "Mouse", "Не найден 'БойцовскийКлуб1.Menu.OpenGroup'. Перегружаем страницу.", repo.БойцовскийКлуб1.Menu.OpenGroupInfo);
	        		Keyboard.Press("{F5}");
	        		ChooseFight();        		
	        	}
            	
            }
            else
            {
            	WinForms.MessageBox.Show("Параметр fightType задан неверно.");            	
            }
            
        }

        public void Validate_ATag1На1()
        {
            Report.Log(ReportLevel.Info, "Validation", "выбор типа боя\r\nValidating Exists on item 'БойцовскийКлуб1.Menu.ATag1На1'.", repo.БойцовскийКлуб1.Menu.ATag1На1Info);
            Validate.Exists(repo.БойцовскийКлуб1.Menu.ATag1На1Info);
        }

        public void Mouse_Click_Поединки()
        {
            
        }

        public void Validate_Поединки()
        {
            Report.Log(ReportLevel.Info, "Validation", "переход в поединки\r\nValidating Exists on item 'БойцовскийКлуб1.Menu.Поединки'.", repo.БойцовскийКлуб1.Menu.МенюInfo);
            Validate.Exists(repo.БойцовскийКлуб1.Menu.МенюInfo);
        }

        public void Mouse_Move_ПрочныйКлинокВластногоЗлодеяF2Уд()
        {
            Report.Log(ReportLevel.Info, "Mouse", "Mouse Right Move item 'БойцовскийКлуб1.Menu.ПрочныйКлинокВластногоЗлодеяF2Уд' at Center.", repo.БойцовскийКлуб1.Menu.ПрочныйКлинокВластногоЗлодеяF2УдInfo);
            repo.БойцовскийКлуб1.Menu.ПрочныйКлинокВластногоЗлодеяF2Уд.MoveTo();
        }

        public void Wait_For_Combats1()
        {
        	try
        	{
            	Report.Log(ReportLevel.Info, "Wait", "Waiting 1m for item 'БойцовскийКлуб1.Menu.Combats1' to exist.", repo.БойцовскийКлуб1.Menu.Combats1Info, new ActionTimeout(60000));
            	repo.БойцовскийКлуб1.Menu.Combats1Info.WaitForExists(60000);
        	}
        	catch(Exception e)
        	{
        		
        		Report.Log(ReportLevel.Info,"Закрываем браузер.");
            		Host.Local.KillBrowser("ie");
            		Delay.Seconds(5);
            		Start();
        	}
        	
        }

    }
}