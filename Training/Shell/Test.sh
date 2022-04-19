#! /usr/bin/bash

f0=0
f1=1
x=1 
y=1

read -p " " sampleInput
while [ $sampleInput -ne $x ]
do
    y=$(( $f1 + $f0 ))
    f0=$f1
    f1=$y
    x=$(( $x + 1))
done

while [ $y -ge 10 ]
do
    val=$(( $y % 10 ))
    y=$(( $y / 10 ))
    results=$(( $results + $val ))
done
results=$(( $results + $y ))
echo $results