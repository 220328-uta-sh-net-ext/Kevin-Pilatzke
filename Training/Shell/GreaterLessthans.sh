#! /usr/bin/bash

re='-?[0-9]+'
echo "Please give a X value" #Hackerrank does not want other types of outputs, added to make it look more user interactive
while true
do  
    read -p "X value: " X 
    if ! [[ $X =~ $re ]]
        then echo "Not a number"
    else break
    fi
done
echo "Please give a Y Value" #Hackerrank does not want other types of outputs, added to make it look more user interactive
while true
do
    read -p "Y value " Y
    if ! [[ $Y =~ $re ]]
        then echo "Not a number"
    else break
    fi
done
if (( $X > $Y ))
    then echo "X is greater than Y"
elif (( $X < $Y ))
    then echo "X is less than Y"
else echo "X is equal to Y"
fi