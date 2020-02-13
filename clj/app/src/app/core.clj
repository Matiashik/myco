(ns app.core
  (:gen-class)
  (:import (java.util Scanner)))

(defn foo []
  (.println System/out "Hello world!"))

(defn input []
  (def res (read-line))
  res)

(defn -main []
  (foo)
  (def a (input))
  (print a) (println "!"))