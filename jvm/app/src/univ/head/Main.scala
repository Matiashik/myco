package univ.head

object Main extends App {
  println("Hello world!")
  var a = (for(i <- 0 to 10 ) yield i)
  println(a)
}