#! /usr/bin/bash

while true
do
    echo "State 'Y' or 'y' for YES and 'N' or 'n' for NO" #Not needed for Hackerrank
    read -p " " option
    if [[ $option = "y" || $option = "Y" ]]
        then echo "YES" ; exit
    elif [[ $option = "n" || $option = "N" ]]
        then echo "NO" ; exit
    elif [[ $option = "exit" ]] #Not needed for Hackerrank
        then exit #Not needed for Hackerrank
    else continue
    fi
done