#!/bin/bash
DIR="$( cd "$(dirname "$0")" ; pwd -P )"

rm -rf $DIR/coverage
mkdir $DIR/coverage

pushd $DIR/coverage
   cmake -DCMAKE_BUILD_TYPE=Coverage ../Source
   make -B
popd

find $DIR/Bin -maxdepth 1 -name "*.Test" -exec {} \;
gcovr -r $DIR/../ --object-directory=$DIR/coverage > $DIR/coverage/coverage.txt
cat $DIR/coverage/coverage.txt
