/* Positions the page to the same scroll axis on invalid submission */

document.addEventListener("DOMContentLoaded", function ()
{
  const scrollY = sessionStorage.getItem("scrollY")
  if (scrollY)
  {
    window.scrollTo({ top: parseInt(scrollY, 10), behavior: "instant" });
    sessionStorage.removeItem("scrollY");
  }
});

document.addEventListener("submit", function (e)
{
  if (e.target.matches("form"))
  {
    sessionStorage.setItem("scrollY", window.scrollY);
  }
});