module Three (three) where

import qualified Data.Text as T
import System.IO.Unsafe (unsafePerformIO)

three :: (Int, Int)
three = (concBol 0 0, concMin 0 0)


dat :: [[Int]]
dat = map f $ T.splitOn (T.pack "\n") (T.pack . unsafePerformIO . readFile $ "Three.csv")
    where
        f a = map ff $ T.splitOn (T.pack ";") a
        ff a  = read (T.unpack a) :: Int


concBol :: Int -> Int -> Int
concBol l n = do
    let a = if l < 11 then concBol (l + 1) n else 0
    let b = if n < 11 then concBol l (n + 1) else 0
    if dat !! l !! n > 100 then -1000 else (
        if a > b then a + dat !! l !! n else b + dat !! l !! n
        )


concMin :: Int -> Int -> Int
concMin l n = do
    let a = if l < 11  then concMin (l + 1) n else 1000
    let b = if n < 11 then concMin l (n + 1) else 1000
    if l == 11 && n == 11 then dat !! l !! n else (
        if dat !! l !! n > 100 then 1000 else (
            if a < b then a + dat !! l !! n else b + dat !! l !! n
            )
        )