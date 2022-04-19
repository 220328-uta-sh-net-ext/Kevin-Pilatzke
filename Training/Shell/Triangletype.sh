#! /usr/bin/bash

re='-?[0-9]+'
read -p "Side 1: " x
read -p "Side 2: " y
read -p "Side 3: " z
    if ! [[ $x =~ $re ]] || ! [[ $y =~ $re ]] || ! [[ $z =~ $re ]]
        then echo "Make sure all sides are numbers"
    elif (( $x < 1 || $x > 1000 )) || (( $y < 1 || $y > 1000 )) || (( $z < 1 || $z > 1000 ))
        then echo "A side is not within range"
    elif (( $x + $y < $z ))
        then echo "Value of X and Y must be larger then z"
    else 
        if [[ $x == $y ]] && [[ $y == $z ]]
            then echo "EQUILATERAL"
        elif [[ $x != $y ]] && [[ $y != $z ]] && [[ $x != $z ]] 
            then echo "SCALENE"
        else 
            echo "ISOSCELES"
        fi
    fi