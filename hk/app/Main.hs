module Main where

import qualified Data.Text as T
import System.IO.Unsafe (unsafePerformIO)


main :: IO ()
main = print (concBol 0 0, concMin 0 0)


dat :: [[Int]]
dat = map f $ T.splitOn (T.pack "\r\n") (T.pack . unsafePerformIO . readFile $ "data.csv")
    where
        f a = map ff $ T.splitOn (T.pack ",") a
        ff a  = read (T.unpack a) :: Int


concBol :: Int -> Int -> Int
concBol l n = do
    let a = if l < 9 then concBol (l + 1) n else 0
    let b = if n < 9 then concBol l (n + 1) else 0
    if a > b then a + (dat !! l) !! n else b + (dat !! l) !! n


concMin :: Int -> Int -> Int
concMin l n = do
    let a = if l < 9 then concMin (l + 1) n else 0
    let b = if n < 9 then concMin l (n + 1) else 0
    if a < b then a + (dat !! l) !! n else b + (dat !! l) !! n