const projects = [
  {
    title: "Flores Fuertes",
    category: "web",
    technologies: "HTML | API's",
    description:
      "Een schoolproject waarin ik heb gewerkt aan een website met HTML en API-koppelingen.",
    details: [
      "Bijdrage: websiteontwikkeling en API-koppelingen",
      "Context: schoolproject"
    ],
    repository: "https://github.com/AnsonM03/Flores-Fuertes"
  },
  {
    title: "Data Engineering",
    category: "data",
    technologies: "Python | SQL | Power BI",
    description:
      "Een schoolproject rond het verwerken en analyseren van gegevens van Great Outdoors.",
    details: [
      "Focus: dataverwerking en analyse",
      "Onderdelen: Python-notebooks, databases en dashboard"
    ],
    repository: "https://github.com/AnsonM03/DEAI-SE4"
  },
  {
    title: "OPT3 - Scrumspel",
    category: "java",
    technologies: "Java | Maven | JUnit",
    description:
      "Een Java-project met onderdelen voor spelers, kamers, items en opdrachten.",
    details: [
      "Focus: objectgeoriënteerd programmeren en testen",
      "Onderdelen: spellogica, spelers en kamers"
    ],
    repository: "https://github.com/AnsonM03/OPT3"
  }
];

const projectList = document.querySelector("#project-list");
const categoryFilter = document.querySelector("#category-filter");
const sortProjects = document.querySelector("#sort-projects");
const projectCount = document.querySelector("#project-count");

const createProjectCard = (project) => {
  const article = document.createElement("article");
  article.className = "card";

  const tag = document.createElement("p");
  tag.className = "tag";
  tag.textContent = project.technologies;

  const title = document.createElement("h2");
  title.textContent = project.title;

  const description = document.createElement("p");
  description.textContent = project.description;

  const metaList = document.createElement("ul");
  metaList.className = "meta-list";

  project.details.forEach((detail) => {
    const listItem = document.createElement("li");
    listItem.textContent = detail;
    metaList.append(listItem);
  });

  const link = document.createElement("a");
  link.className = "button secondary";
  link.href = project.repository;
  link.target = "_blank";
  link.rel = "noopener noreferrer";
  link.textContent = "Bekijk de code op GitHub";

  article.append(tag, title, description, metaList, link);

  return article;
};

const getVisibleProjects = () => {
  const selectedCategory = categoryFilter.value;
  const sortDirection = sortProjects.value;

  const filteredProjects =
    selectedCategory === "alle"
      ? projects
      : projects.filter((project) => project.category === selectedCategory);

  return [...filteredProjects].sort((firstProject, secondProject) => {
    const comparison = firstProject.title.localeCompare(
      secondProject.title,
      "nl"
    );

    return sortDirection === "az" ? comparison : -comparison;
  });
};

const renderProjects = (visibleProjects) => {
  projectList.replaceChildren();

  visibleProjects.forEach((project) => {
    projectList.append(createProjectCard(project));
  });

  projectCount.textContent = `${visibleProjects.length} projecten zichtbaar.`;
};

const updateProjectList = () => {
  const visibleProjects = getVisibleProjects();
  renderProjects(visibleProjects);
};

categoryFilter.addEventListener("change", updateProjectList);
sortProjects.addEventListener("change", updateProjectList);

updateProjectList();