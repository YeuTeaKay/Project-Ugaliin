INCLUDE globals.ink
{ playerProgress == 0: -> TalkToMother}
{ playerProgress >= 1: -> TitasHouse}
{ TitaHouseEnd == true: -> EndDialogue}


=== TalkToMother ===
#speaker:KapitBahay  #portrait:KapitBahay_Talking #layout:Default #voiceover:default
Hey Luad! very busy right now, and your mother said to talk to her about something
->DONE

=== TitasHouse ===
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
Luad visits their aunt or “Tita” to greet them and says they have already arrived in the community. 
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
She is the sister of Luad’s mother, who also has a child, Luad’s cousin.

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
Oh Luad! You guys have moved in already! Come inside first to have some snacks and let's talk for a bit.
+[Oh don't worry tita! It's fine, I don't want to bother you guys.]
    ~goodChoicesCounter += 1
    ->goodChoice0("choiceItem5")
+[Okay tita thank you! Coming in!]
    ~goodChoicesCounter += 1
    ->NextDialogue0
+[No it's okay, I'll just go.]
    ~badChoicesCounter += 1
    ->NextAngryDialogue0
    
=== goodChoice0(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Hiya #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>HIYA!</b>

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
Don't be shy! I consider you as my child too so come on in, just go inside.
    ->NextDialogue1

=== NextAngryDialogue0 ===
#speaker:Tita Grace  #portrait:Tita_Angry_Talking #layout:Default #voiceover:default
Don't be like that! Get in so that we can catch up and talk about how you guys are.
    ->NextDialogue1
    
=== NextDialogue0 ===
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
Looks like you're still cheery as ever! Go on inside, don't be shy.
    ->NextDialogue1
    
=== NextDialogue1 ===
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
Sorry for the mess, I've been kind of busy lately. 
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
Anyway, Luad how are you? How is your mother? 
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
You guys have moved already, you should have told me so that I could have helped you. 
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
You've grown so much!

+[Oh don't worry tita! It's fine, I don't want to bother you guys.]
    ~goodChoicesCounter += 1
    ->goodChoice1("choiceItem5")
+[Okay tita thank you! Coming in!]
    ~goodChoicesCounter += 1
    ->goodChoice2("choiceItem3")
+[No it's okay, I'll just go.]
    ~badChoicesCounter += 1
    ->NextDialogue2
=== goodChoice1(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Hiya #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>HIYA!</b>
    ->NextDialogue2
    
=== goodChoice2(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:CloseFamilyTies #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>CLOSE FAMILY TIES!</b>
    ->NextDialogue2
    
=== NextDialogue2 ===
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
I'm really sorry, I haven't prepared anything for you guys.

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
I've been busy with work and taking care of your cousin. I'll make it up to you guys next time.

+[It's really okay tita. Come visit us sometime, mom will be glad to see you. Our house is open for you guys anytime. ]
    ~goodChoicesCounter += 1
    ->goodChoice3("choiceItem6")
+[It's really okay tita. Just stick to it, you can do it! You'll overcome it eventually. Just trust!]
    ~goodChoicesCounter += 1
    ->goodChoice4("choiceItem1")
    
=== goodChoice3(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Hospitality #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>HOSPITALITY!</b>
    ->NextDialogue3
    
=== goodChoice4(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:BahalaNa #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>BAHALA NA!</b>
    ->NextDialogue3
    
=== NextDialogue3 ===
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
You're really kind Luad! Oh speaking of, here is your cousin. Ellie, come here. 

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
This is your cousion Luad. You guys have met a long time ago, Ellie was still a baby that time so she is not familiar with you.

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
I'll leave you guys here okay? I'll just make some snacks.

#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
H-hello! My name is Ellie! I don't remember you but mama said that you're my cousin.

#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
Looks like I have a new playmate!  But, even though I want to play with you, 

#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
I can't. We have a test next week. I still need to study. Probably next time we can play.

+[Okay, study well Ellie. I'll just come back next time so that we can play together.]
    ~goodChoicesCounter += 1
        ->NextDialogue4
+[It's still next week! Just study next week, you're smart right?]
    ~badChoicesCounter += 1
    ->badChoice0("choiceItem7")
    
=== badChoice0(choiceItem) ===
~playerChoice = choiceItem
#speaker:Narrator  #portrait:Manana #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>MANANA!</b>

#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
No I can't! I need to study because I want to stay as an honor student so that mama will be proud of me.
    ->NextDialogue5
    
=== NextDialogue4 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
Yay! Thanks cousin! Next time, we'll play hide-and-seek and with my toys!
    ->NextDialogue5
    
=== NextDialogue5 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
Oh I know! So that we can do something today, is it okay for you to help me study?

#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
I'll just be asking questions about topics that I can't understand.

#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
Come on cousin, please?

+[Sure! That's a nice idea so that you'll get good grades.]
    ~goodChoicesCounter += 1
    ->MiniGame
+[Nah, you can do that yourself. You're smart enough.]
    ~badChoicesCounter += 1
    ~playerProgress += 1
    ->EndDialogue
    
=== MiniGame ===
~playerPoints = 0

->Question1
=== Question1 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
This value refers to acting in consideration of others which will be eventually reciprocated to them.

+[Bayanihan]
    ->WrongAnswer1
+[Pakikisama]
    ->RightAnswer1
+[Utang na Loob]
    ->WrongAnswer1
    
=== RightAnswer1 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Pakikisama!</b>.
    ->Question2
=== WrongAnswer1 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Pakikisama!</b> Luad!.
    ->Question2
    
=== Question2 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
Which action shows the value "Bayanihan"?

+[Preparing food for your guests.]
    ->WrongAnswer2
+[Helping set up banners for the fiesta.]
    ->RightAnswer2
+[Joining the local basketball team.]
    ->WrongAnswer2
    
=== RightAnswer2 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Helping set up banners for the fiesta!</b>.
    ->Question3
=== WrongAnswer2 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Helping set up banners for the fiesta!</b> Luad!.
    ->Question3

=== Question3 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
This value refers to having a passive tendency to negative consequences.

+[Bahala Na]
    ->RightAnswer3
+[Respect for the Elderly]
    ->WrongAnswer3
+[Utang na Loob]
    ->WrongAnswer3

=== RightAnswer3 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Bahala Na!</b>.
    ->Question4
=== WrongAnswer3 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Bahala Na!</b>
    ->Question4

=== Question4 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
Define the value of "Amor Propio".

+[Having close relations with your family members.]
    ->WrongAnswer4
+[Being inclined to procrastinate.]
    ->WrongAnswer4
+[Viewing oneself as competent.]
    ->RightAnswer4

=== RightAnswer4 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Viewing oneself as competent!</b>.
    ->Question5
=== WrongAnswer4 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Viewing oneself as competent</b>
    ->Question5

=== Question5 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
This value refers to having a tendency to begin something and not finish.

+[Hiya]
    ->WrongAnswer5
+[Bahala Na]
    ->WrongAnswer5
+[Ningas Cogon]
    ->RightAnswer5

=== RightAnswer5 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Ningas Cogon!</b>.
    ->Question6
=== WrongAnswer5 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Ningas Cogon</b>
    ->Question6

=== Question6 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
Which action shows the value "Hiya"?

+[Apologizing for not preparing food for guests.]
    ->RightAnswer6
+[Greeting elderly people with "mano po".]
    ->WrongAnswer6
+[Help in cleaning up the streets of your neighborhood.]
    ->WrongAnswer6

=== RightAnswer6 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Apologizing for not preparing food for guests!</b>.
    ->Question7
=== WrongAnswer6 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Apologizing for not preparing food for guests</b>
    ->Question7
    
=== Question7 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
Define the value of "Hospitality"?

+[Apologizing to the guests for not cleaning the house.]
    ->WrongAnswer7
+[Touring the guests around your home.]
    ->RightAnswer7
+[Helping an old lady cross the street.]
    ->WrongAnswer7

=== RightAnswer7 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Touring the guests around your home!</b>.
    ->Question8
=== WrongAnswer7 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Touring the guests around your home</b>
    ->Question8

=== Question8 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
Your friend keeps on expressing their gratitude to you even though you helped them a long time ago. What value does your friend show?

+[Close Family Ties]
    ->WrongAnswer8
+[Utang na Loob]
    ->RightAnswer8
+[Hiya]
    ->WrongAnswer8

=== RightAnswer8 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Utang na Loob!</b>.
    ->Question9
=== WrongAnswer8 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Utang na Loob</b>
    ->Question9

=== Question9 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
This value refers to having the tendency to put off work and doing something else instead.

+[Mañana Habit]
    ->RightAnswer9
+[Ningas Cogon]
    ->WrongAnswer9
+[Utang na Loob]
    ->WrongAnswer9

=== RightAnswer9 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Mañana Habit!</b>.
    ->Question10
=== WrongAnswer9 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Mañana Habit</b>
    ->Question10

=== Question10 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
Your community has a patron saint, which yearly celebrates their feast day. Which value does the community show?

+[Bayanihan]
    ->WrongAnswer10
+[Pakikisama]
    ->WrongAnswer10
+[Fiesta Grande]
    ->RightAnswer10

=== RightAnswer10 ===
~playerPoints += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We are right Luad! it's said it was <color="green"><b>Fiesta Grande!</b>.
    ->CheckScore
=== WrongAnswer10 ===
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Quiz #voiceover:default
We were wrong it's said it was <color="green"><b>Fiesta Grande</b>
    ->CheckScore

=== CheckScore ===
{ playerPoints >= 7: -> YouWin("choiceItem2") }
{ playerPoints <= 6: -> YouLose }

=== YouWin(choiceItem) ===
~playerChoice = choiceItem
~goodChoicesCounter += 1
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
We got most of the orders correctly!

#speaker:Narrator  #portrait:Bayanihan #layout:Default #voiceover:default
You Have Obtained <color="blue"><b>BAYANIHAN!</b>
    ->NextDialogue11

=== YouLose ===
#speaker:Narrator  #portrait:Default #layout:Default #voiceover:default
We didn't get most of the orders correctly! Do you want to try again?
+[Try Again?]
    ->NextDialogue11
+[End Game]
    ~badChoicesCounter += 1
    ->badChoice1("choiceItem8")
=== badChoice1(choiceItem) ===
~playerChoice = choiceItem

#speaker:Narrator  #portrait:NingasKugon #layout:Default #voiceover:default
You Have Obtained <color="red"><b>NINGAS COGON!</b>
    ->NextDialogue11

=== NextDialogue11 ===
~playerProgress += 1
#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
Thanks for your help cousin! I really hope that I can pass the test and get a high grade.

#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
As long as the next time you come, we'll play, right? You promised! 

#speaker:Ellie  #portrait:Pinsan_Talking #layout:Default #voiceover:default
Oh right! Mama is here with snacks!

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
Oh I hope Ellie did not bother you too much. But really, thank you very much Luad. 

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
You guys are nearby now so we can spend time together from time to time. 

#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
Always remember, our house is always open for you guys. Okay then, eat! Don't be shy!

    ->EndDialogue
    
=== EndDialogue ===
~TitaHouseEnd = true
#speaker:Tita Grace  #portrait:Tita_Talking #layout:Default #voiceover:default
Go talk to other people to get know the area!

->END
