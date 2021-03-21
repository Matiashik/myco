module Six (six) where

import qualified Data.Text as T
import System.IO.Unsafe (unsafePerformIO)

qt :: Int -> Int -> Int
qt l n = -(dat !! l !! n `rem` 2) + 2

six :: (Int, Int)
six = (concBol 0 0, concMin 0 0)


dat :: [[Int]]
dat = map f $ T.splitOn (T.pack "\n") (T.pack . unsafePerformIO . readFile $ "Six.csv")
    where
        f a = map ff $ T.splitOn (T.pack ";") a
        ff a  = read (T.unpack a) :: Int


concBol :: Int -> Int -> Int
concBol l n = do
    let a = if l < 9 then concBol (l + 1) n else 0
    let b = if n < 9 then concBol l (n + 1) else 0
    if a > b then a + qt l n else b + qt l n
        


concMin :: Int -> Int -> Int
concMin l n = do
    let a = if l < 9  then concMin (l + 1) n else 1000
    let b = if n < 9 then concMin l (n + 1) else 1000
    if l == 9 && n == 9 then qt l n else (
        if a < b then a + qt l n else b + qt l n
        )