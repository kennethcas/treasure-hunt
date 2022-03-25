-> main

===main===
Hello.
Finally we get to speak to each other.
    + [...]
        -> tryAndSpeak
    + [...]
        -> tryAndSpeak
    + [...]
        -> tryAndSpeak
    
===tryAndSpeak===
Try to talk. You should be able to do it now.
    + [What should I say?]
        -> whatShouldISay
    + [Hello]
        -> respondingToHello
    + [Could I talk this whole time?]
        -> couldITalkThisWholeTime

===respondingToHello===
Hi. It's nice to finally be able to talk to you.
    + [How come I can talk now?]
    -> howComeICanTalkNow
    
===whatShouldISay===
You can start by saying hello.
    + [Hello]
        -> respondingToHello
    + [Hi]
        -> respondingToHello
    + [Hey]
        -> respondingToHello
        
===howComeICanTalkNow===
I don't know. For some reason you just gained this ability. 
Just like me and the other statues. We couldn't communicate until now.
    -> endOfJourney
        
===couldITalkThisWholeTime===
Nope. For some reason you just gained this ability. 
Just like me and the other statues. We couldn't communicate until now.
    ->endOfJourney

===endOfJourney===
I'm afraid we won't get to know each other too well.
This is the end of your journey.
+ [Are you going to kill me?]
    No no.
    This is just it. There's nothing beyond this last space.
    I don't know much. I've never been able to go anywhere else or see other places. But I know that once you go past here, there's nothing more.
    I hope you enjoyed the journey so far.
    This is it.
    ->nearTheEnd
    
+ [That's it?]
    ->thatsIt
    
===thatsIt===
Yeah.
You still have to get out the same way. Gather the three keys and blah blah blah. 
But now you know you don't have to rush. 
You finally have the ability to talk to others here. 
This one ghost is especially lonely.
He really wants to talk to you, even though he pretends to be tough.
He even stole and hid one of the keys. So that you would have to talk to him.
Anyway.
Good luck on the rest of your journey. No matter what it may or may not be. 
And try and make the most of it.
+ [Thank you. I will]
    -> END
+ [Goodbye]
    -> END

===nearTheEnd===
You still have to get out the same way. Gather the three keys and blah blah blah. 
But now you know you don't have to rush. 
You finally have the ability to talk to others here. 
This one ghost is especially lonely.
He really wants to talk to you, even though he pretends to be tough.
He even stole and hid one of the keys. So that you would have to talk to him.
Anyway.
Good luck on the rest of your journey. No matter what it may or may not be. 
And try and make the most of it.
+ [Thank you. I will]
    -> END
+ [Goodbye]
    -> END

->END