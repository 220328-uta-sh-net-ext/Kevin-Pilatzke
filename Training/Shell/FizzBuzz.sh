#! /usr/bin/bash
: "FizzBuzz Activity
-W.A.P in shell scripting with following conditions:
    -For a number between 1 to 20, print fizz if a number is divisible by 3
    -Print buzz if the number is divisible by 5
    -Print fizzbuzz if the number is divisible by both 3 and 5
    -Print nothing if the number isn't divisible by 3 or 5
-Create the file by name fizzbuzz.sh"

echo "Hello! Would you like to play a game?"
while true
do
    echo "Pick a number from 1 to 20 [Type quit to exit game]"
    read -p "Option: " Option

    if [[ $Option = "quit" ]]
        then break
    elif (( 21 > $Option < 1 ))
        then echo "Not a number between 1 and 20"
    elif (( $Option <= 0 ))
        then echo "Not a number between 1 and 20"
    elif (( $Option == 15 ))
        then echo "FizzBuzz"
    elif (( $Option % 3 == 0 ))
        then echo "Fizz"
    elif (( $Option % 5 == 0 ))
        then echo "Buzz"
    else echo "Nothing"
    fi
done
echo "Thanks for playing!"