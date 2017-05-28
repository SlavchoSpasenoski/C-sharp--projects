Проектна задача по Визуелно Програмирање


1.	Објаснување на проблемот

•	За оваа проектна задача ја направивме играта Western Takedown. Играта започнува со првото пукање. Во исто време започнува и тајмер од 30 секунди да брои. Кога ќе дојде тајмерот на 10 секунди, се прави во црвена боја за да предупреди дека времето е при крај. Со секое пукање се намалува бројот на преостанати пукања. На секои 10 погодувања во метата, се зголемува нивото на игра, се додаваат +15 пукања и времето се рестартира на 30 секунди за секое наредно ниво, како и се забрзува движењето на метата. На трето ниво се прикажува уште една мета за пукање, а на четврто ниво се додава уште една. Доколку истече времето или се потрошат пукањата, играта завршува.

2.	Опишување на решението на проблемот
Проектот Western takedown содржи две windows форми(Form1, HighScores) и една класа Players.

-	Опис на функцијата Shots()

Овој метод има улога да ги регистрира сите “погодоци” во текот на играта односно со клик на picturebox 1, 2, 4 движечките контроли,односно каубоите (метите).Истиот содржи променливи (Hits, bullets)кои што се зголемуваат/намалуваат соодветно при секој погодок, односно клик на PictureBox1,2,3 контролите.Променливите ги прикажуваат соодветните лабели со наслова.Исто така овој метод содржи и 1 услов каде што ги зголемува нивоата на игра, односно проверува дали сме постигнале 10 погодоци за да одиме на следниот левел. Тоа го постигнавме со Пгодоци по модул 10, односно за секој 10 ти погодок, следува нареден левел, а воедно бројот на муниција се зголемува за 15.Оваа функција ја повикуваме кај сите каубои односно picturebox контроли.

-	Опис на функцијата Misses()

Оваа функција е спротивна на предходната (Shots()), истата содржи променливи (misses, totalShots)кои што се всушност бројачи на промаршувања и вкупни број кликови (промаршени и погодени). Како и предходната и во оваа бројачите се прикажуваат во соодветните лабели, и истата се повикува во Form1_MouseClick методот.

-	Опис на функцијата Reset()

Оваа функција игра улога по завршување на играта, односно сите променливи, бројачи, лабели и тајмери да се сетираат на предефинираната почетна состојба. Reset() се повикува со клик на копчето Reset, односно Button1_Click() методот;

-	Timer1, Timer2, Timer3

o	Timer1
	кој е поставен на почетен интервал 1000, игра улога на брзина на движење на метите (каубоите) кои ние треба да ги погодуваме, ф-јата содржи координати по кои ќе ги движиме метите, како и Randomобјект кој случајно ја избира позицијата на прикажување на метата, истото го правиме за сите мети, но под услов метите да се појавуваат во одредено ниво на играта, а воедно за секое наредно ниво, Timer1 го намалуваме за 100, односно го забрзуваме движењето на метите, а со тоа постигнуваме ефект на тежина на играта.

o	Timer2 
	е искористен како функција, каде што ги брои муниција и при што истата стигне до 0, играта застанува, се поставува на true лабелата сотекст “GAME OVER” и се прикажува HighScoresформата во која со задолжително поле мора да го внесете вашето име, каде што се регистрира во табелата за најдобри играчи.


o	Timer3 
	ја извршува функцијата на Тајмер на нивоа, односно истиот е поставен на интервал 1000, односно 1 секунда и содржи интеџер променлива која што има почетна вредност 30, и се минусира на секој интервал од тајмерот, така што ни симулира 30 секунди одбројување по 1 ниво. Доколку го постигнете резултатот од 10 погоци, бројачот се ресетира на 30, и се зголемува нивота за +1, воедно доколку бројачот брои <=10, тогаш истиот се обојува во црвено како знак за предупредување за недостаток на време. Доколку тајмерот заврши повторно се ресетираат сите тајмери, лабели и се испишува GAME OVER LOOSER!!!


-	HighScores форма

Оваа форма служи за регистрирање на поените и играчите од играта, истата се повикува откако ќе заврши играта.
o	Содржи лабела за внес на име која што е задолжително поле, и 4 butons (Save, NewGame, Best cowboys, exit)
o	Save – проверува дали Textbox-от далие празен, и При повик на објект од класата Players го вметнува во листа, името и постигнатите поени од завршената игра.
o	NewGame – повикува нова форма (Form1 ) со почетни вредности, старата ја затвора.
o	Bestcowboys – Пребарува во класата Players за внесените вредности од 1 сесија на играње, и ги додава во посебен MessageBoxпрозорец.
o	Exit – ја затвора апликацијата.

3.	Screenshots од изгледот на апликацијата/играта
   ![alt text](https://github.com/SlavchoSpasenoski/C-projects/blob/master/Sliki/prva.jpg)

•	Кога апликацијата ќе се стартува таа изгледа како на следнава слика:


	Во горниот лев дел на прозорецот се прикажани погодоци, промаршувања и вкупен број на поени, заедно со приказ на ниво на игра (level). Се започнува од ниво 1. Во средишниот горен дел стои бројач на време за нивото (30 секунди за секое ниво) како и број на пукања (се почнува со 50 пукања). Десно на екранот се наоѓаат копчиња за рестарт и за излез од играта. 


•	Доколку времето истече под 10 секунди, се менува бојата на бројачот во црвена.

![alt text](https://github.com/SlavchoSpasenoski/C-projects/blob/master/Sliki/vtora.jpg)
	
•	Откако ќе истече времето за пукање, се прекинува играта и се прикажува GAME OVER LOOSER!!! како и прозорец за HighScores. Исто така играта се прекунува и доколку се потрошат пукањата (bullets).
![alt text](https://github.com/SlavchoSpasenoski/C-projects/blob/master/Sliki/treta.jpg)

На сликата подоле е прикажан прозорецот HighScores каде што може да се зачуваат поените (се внесува име), да се започне нова игра, да се види ранг листата или да се излезе од играта:
![alt text](https://github.com/SlavchoSpasenoski/C-projects/blob/master/Sliki/cetvrta.jpg)









	Доколку се кликне на полето Best cowboys, се прикажува ранг листата со поени:
![alt text](https://github.com/SlavchoSpasenoski/C-projects/blob/master/Sliki/petta.jpg)
 

