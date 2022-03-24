-> main

===main===
Took you a while to get here.
I felt like I was going to die from boredom.
Like you made me wait so long that I thought I was going to die. Again.
But anyway. 
'Tis I. The "final boss" as some may say.
You're looking for the last key, aren't you?
Well, I have it.
+ [Cool. Where is it?]
    -> bePatient
+ [Are you going to give it to me?]
    -> bePatient
    
===bePatient===
Patience. I can't just give it to you for free.
The statues kept telling me I had to do something 'special' or whatever.
But to be honest I still don't have anything concrete.
lol
+ [What if you just hand it over?]
    ->justHandItOver
+ [I could help you think of something]
    ->thinkOfSomething
+ [Goodbye]
    ->END
    
===justHandItOver===
Nah, I can't do that.
The statues will complain about it forever.
Literally.
Hey... I have an idea.
You could just help me choose what do to.
I was bouncing between three choices.
    +[Alright, let me pick]
    Cool, cool. 
    Okay so would you rather solve a riddle, or solve another riddle, or solve a different riddle.
        -> sameRiddles
        
===sameRiddles===
+ [Those are all the same choices, though?]
They're not I promise. They are all different riddles. 
    ->okayIWillChoose
    
===okayIWillChoose===
+[Alright.]
Cool, cool. So which riddle will it be?
    ->chooseRiddle
    
===chooseRiddle===
+[first riddle]
    ->firstRiddle
+[second riddle]
    ->secondRiddle
+[third riddle]
    ->thirdRiddle
    
===firstRiddle===
Ah, the first riddle. Good choice.
Okay, here it is.
You see a boat filled with people. It has not sunk, but when you look again you don't see a single person on the boat. Why?
    +[Everyone jumped overboard.]
        -> wrongAnswer
    +[I looked again hours later?]
        -> wrongAnswer
    + [All the people were married]
        ->rightAnswer

===secondRiddle===
The second riddle. Okayy
I have keys, but no locks. I have space, but no rooms. You can enter, but you can't go outside. What am I?
    + [A keyboard]
        -> rightAnswer
    + [Some kind of mysterious abyss]
        -> wrongAnswer
    + [...]
        -> wrongAnswer

===thirdRiddle===
The last riddle. Wow this is a real hard one.
I speak without a mouth and hear without ears. I have no body, but I come alive with wind. What am I?
    + [Silence]
        -> wrongAnswer
    + [An echo]
        -> rightAnswer
    + [A fart]
        -> wrongAnswer


===thinkOfSomething===
I guess. I was already bouncing between these three ideas. You could just pick one of those.
    +[Alright, let me pick]
        Cool, cool. 
    Okay so would you rather solve a riddle, or solve another riddle, or solve a different riddle.
        -> sameRiddles

===wrongAnswer===
Nope. Wrong answer.
It's ok. I forgive you.
I would give you another riddle but honestly I forgot the other ones lol.
I'll just give you the key. Its a little bit behind me. 
I'm only giving it to you because you're a nice guy ok.
You shouldn't be trapped in this place like the rest of us. 
You should go ahead and find out what else is out there. 
And if you come back as a ghost there's always more space for you here.
Alright, goodbye. And good luck.
    +[Goodbye]
        ->END

===rightAnswer===
That's right! Wow you're so smart.
The key should be a little bit behind me now. Take it and get out of here.
You shouldn't be trapped in this place like the rest of us.
You should go ahead and find out what else is out there.
And if you come back as a ghost there's always a place for you here.
Alright, goodbye.
Didn't mean to get all philosphical and emotional there.
Good luck.

-> END