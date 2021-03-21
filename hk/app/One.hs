module One (one) where

import qualified Data.Text as T
import System.IO.Unsafe (unsafePerformIO)

dat :: [Int]
dat = f (T.pack . unsafePerformIO . readFile $ "One.csv")
    where
        f a = map ff $ T.splitOn (T.pack ";") a
        ff a  = read (T.unpack a) :: Int

one :: Int
one = func1 0

func1 :: Int -> Int
func1 i
    | i == (length dat - 1) = func2 i 0
    | otherwise = func2 i 0 + func1 (i + 1)

func2 :: Int -> Int -> Int
func2 i j
  | i - j < 4 = 0
  | even (dat !! i + dat !! j) = 1 + func2 i (j+1)
  | otherwise = func2 i (j+1)