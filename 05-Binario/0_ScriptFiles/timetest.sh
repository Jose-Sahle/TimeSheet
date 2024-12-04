#!/bin/bash

function displaytime {
  local T=$1
  local H=$((T/60/60%24))
  local M=$((T/60%60))
  local S=$((T%60))
  printf "Tempo decorrido: %02dh%02dm%02ds\n" $H $M $S
}
