module Two (two) where

import qualified Data.Text as T
import System.IO.Unsafe (unsafePerformIO)

dat :: [Int]
dat = f (T.pack . unsafePerformIO . readFile $ "Two.csv")
    where
        f a = map ff $ T.splitOn (T.pack ";") a
        ff a  = read (T.unpack a) :: Int

two :: Int
two = func1 0

func1 :: Int -> Int
func1 i
    | i == length dat - 1 = func2 i 0
    | otherwise = func2 i 0 + func1 (i + 1)

func2 :: Int -> Int -> Int
func2 i j
  | j >= i = 0
  | dat !! i + dat !! j < 100 && i - j > 5 = 1 + func2 i (j+1)
  | otherwise = func2 i (j+1)