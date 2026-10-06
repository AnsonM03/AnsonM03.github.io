const contactForm = document.querySelector("#contact-form");
const formStatus = document.querySelector("#form-status");
const formFields = Array.from(
  contactForm.querySelectorAll("input, textarea")
);

const emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;

const getErrorElement = (field) => {
  return document.querySelector(`#${field.name}-error`);
};

const validateField = (field) => {
  const value = field.value.trim();
  let errorMessage = "";

  if (field.name === "name" && value.length < 2) {
    errorMessage = "Vul een naam van minimaal 2 tekens in.";
  }

  if (field.name === "email" && !emailPattern.test(value)) {
    errorMessage = "Vul een geldig e-mailadres in.";
  }

  if (field.name === "message" && value.length < 20) {
    errorMessage = "Je bericht moet minimaal 20 tekens bevatten.";
  }

  const errorElement = getErrorElement(field);
  errorElement.textContent = errorMessage;
  errorElement.hidden = errorMessage === "";

  if (errorMessage) {
    field.setAttribute("aria-invalid", "true");
    return false;
  }

  field.removeAttribute("aria-invalid");
  return true;
};

const clearFormErrors = () => {
  formFields.forEach((field) => {
    const errorElement = getErrorElement(field);
    errorElement.textContent = "";
    errorElement.hidden = true;
    field.removeAttribute("aria-invalid");
  });
};

formFields.forEach((field) => {
  field.addEventListener("blur", () => {
    validateField(field);
  });

  field.addEventListener("input", () => {
    if (field.getAttribute("aria-invalid") === "true") {
      validateField(field);
    }
  });
});

contactForm.addEventListener("submit", (event) => {
  event.preventDefault();

  const formIsValid = formFields
    .map((field) => validateField(field))
    .every(Boolean);

  if (!formIsValid) {
    formStatus.textContent = "Controleer de velden met een foutmelding.";
    return;
  }

  formStatus.textContent =
    "Je bericht is gecontroleerd en klaar om verzonden te worden.";
  contactForm.reset();
  clearFormErrors();
});