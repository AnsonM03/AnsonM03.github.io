# Onderbouwing ontwerpkeuzes

## Gebruikersscenario's

**Scenario 1: een recruiter bekijkt mijn projecten.**  
De recruiter wil snel begrijpen wat ik kan, welke rol ik had en welke technieken ik heb gebruikt. Daarom staat de pagina `projecten.html` in duidelijke projectkaarten met per project een korte beschrijving, status en rol.

**Scenario 2: een docent of beoordelaar controleert mijn leerproces.**  
De docent wil zien of de site semantisch is opgebouwd, responsive werkt en of ik mijn keuzes kan uitleggen. Daarom zijn er aparte pagina's voor profiel, projecten en blog, plus documentatie over request/response en ontwerpkeuzes.

## Drie ontwerpkeuzes

**1. Semantische HTML5-structuur**  
Elke pagina gebruikt herkenbare elementen zoals `header`, `nav`, `main`, `section`, `article` en `footer`. Dit ondersteunt scenario 2, omdat de opbouw van de pagina beter controleerbaar en toegankelijker is. MDN beschrijft semantische HTML als HTML waarbij elementen betekenis geven aan de structuur van de inhoud.

**2. Responsive layout met CSS Grid en Flexbox**  
De projectkaarten staan op desktop naast elkaar, maar vallen op tablet en mobiel onder elkaar. De navigatie kan afbreken naar meerdere regels. Dit ondersteunt scenario 1, omdat een recruiter de site ook op een telefoon of tablet zonder horizontaal scrollen kan lezen.

**3. Duidelijk contrast en beperkte tekstbreedte**  
De tekstkleur is donker op een lichte achtergrond en belangrijke acties hebben een duidelijke kleur. Lange teksten hebben een maximale breedte, zodat regels niet te lang worden. Dit ondersteunt beide scenario's, omdat bezoekers informatie sneller kunnen scannen en lezen.

## Gebruikte bronnen

- MDN Web Docs, "HTML: HyperText Markup Language", geraadpleegd voor semantische HTML: https://developer.mozilla.org/en-US/docs/Web/HTML
- web.dev, "Responsive web design basics", geraadpleegd voor responsive ontwerpprincipes: https://web.dev/responsive-web-design-basics/
