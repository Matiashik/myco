module Main where

import qualified Data.Text as T
import System.IO.Unsafe (unsafePerformIO)

import One (one)
import Two (two)
import Three (three)
import Four (four)
import Five (five)
import Six (six)

main :: IO ()
main = do
    print One.one
    print Two.two 
    print Three.three
    print Four.four 
    print Five.five 
    print Six.six 