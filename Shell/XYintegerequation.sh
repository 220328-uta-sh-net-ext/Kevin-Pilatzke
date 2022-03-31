#! /usr/bin/bash

re='-?[0-9]+'
echo "Need a X and Y Value between -100 and 100" #Hackerrank does not want other types of outputs, added to make it look more user interactive
echo "Please give a X value" #Hackerrank does not want other types of outputs, added to make it look more user interactive
while true
do  
    read -p "X value: " X 
    if ! [[ $X =~ $re ]]
        then echo "Not a number"
    elif (( X >= -100 && X <= 100 ))
        then break
    else echo "Not within range"
    fi
done
echo "Please give a Y Value" #Hackerrank does not want other types of outputs, added to make it look more user interactive
while true
do
    read -p "Y value " Y
    if ! [[ $Y =~ $re ]]
        then echo "Not a number"
    elif [[ "$Y" = 0 ]]
        then echo "Can not use 0 for Y"
    elif (( Y >= -100 && Y <= 100 ))
        then break
    else echo "Not within range"
    fi
done
add=$(( X + Y )) 
sub=$(( X - Y )) 
mult=$(( X * Y ))
div=$(( X / Y ))  
echo $add
echo $sub
echo $mult
echo $div