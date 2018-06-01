# Primzahlen-Suchen-Fermat-Lagrange-WinForms

Primzahlen Suchen mit den Formeln der Mathematiker  
- Pierre de Fermat   
- Joseph-Louis Lagrange 

Dadurch höhere Sicherheit das Prim ist!

## Fast keine Grenzen der Stellen mehr!! :))))

![Animation](https://github.com/sauternic/Primzahlen-Suchen-Fermat-Lagrange-WinForms-V2.1.0/blob/master/Fermat_Lagrange.gif)

### 1000 Stellen und Mehr kein Problem für dieses Programm! :)))

**Motor des Programms ist die statische ModPow() Methode von der Klasse BigInteger.**

Basis eingeben von 2 Angefangen, je höher desto sicherer Prim aber dauert auch länger.     
Denn es werden alle Basise durchgerechnet bevor Prim Test bestanden wird     
(von 2 bis zur Angegebenen). Schon mit Basis 20 werden mit dem Lagrange Test  
**starke fermatische Pseudoprimzahlen Erkannt und Verworfen!**

------

Für Mathematiker (Fermat):  

```
a = Basis
P = Primzahl

Formel:    
a hoch (P-1) Kongruent zu 1 (Modulo P)
```

Für Mathematiker (Lagrange):  

```
a = Basis
P = Primzahl

Formel:    
a hoch ((P-1)/2) Kongruent zu 1 oder P-1 (Modulo P)
```

-----

## Ps:
#### In den meisten Erklärungen fehlt die 0 als gültiges Ergebnis!: 
- Fermat:    a hoch (P-1) Kongruent zu 1 **oder 0** (Modulo P)
- Lagrange:  a hoch ((P-1)/2) Kongruent zu 1 **oder 0** oder P-1 (Modulo P)

### Warum 0
Entsteht immer wenn Basis und Primzahl den gleichen Wert haben  
oder die Basis ein Vielfaches von der Primzahl ist

Gilt für beide Tests!
