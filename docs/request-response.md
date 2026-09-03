# Request/response-schema

Dit schema beschrijft wat er gebeurt wanneer een bezoeker de portfoliosite opent.

1. De bezoeker typt het adres van de site in de browser of klikt op een link.
2. De browser stuurt een HTTP-request naar de webserver, bijvoorbeeld voor `index.html`.
3. De server zoekt het gevraagde bestand op en stuurt een HTTP-response terug.
4. De response bevat onder andere een statuscode, zoals `200 OK`, en de HTML-inhoud.
5. De browser leest de HTML en ontdekt gekoppelde bestanden, zoals `assets/css/styles.css` en `assets/img/portfolio-mark.svg`.
6. Voor deze bestanden stuurt de browser nieuwe requests.
7. Zodra de responses binnen zijn, bouwt de browser de pagina op en toont deze aan de bezoeker.
8. Wanneer de bezoeker via de navigatie naar `projecten.html` of `blog.html` gaat, begint dezelfde cyclus opnieuw voor die pagina.

Kort overzicht:

```text
Browser -> request voor HTML -> Server
Browser <- response met HTML <- Server
Browser -> requests voor CSS/afbeeldingen -> Server
Browser <- responses met CSS/afbeeldingen <- Server
Browser toont de complete pagina aan de bezoeker
```
