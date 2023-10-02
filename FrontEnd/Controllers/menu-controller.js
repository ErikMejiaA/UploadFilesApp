import { verOculatarSeleccion } from "./veroculatar-menu.js";
export { initMenu };

const initMenu = () => {
    document.querySelectorAll('.optMenu').forEach((val, op) => {
        val.addEventListener('click', (e) => {
            const data = e.target.dataset.opcion;
            switch (data) {

                case 'rteam':
                    let data4 = [["#teams"], ["#imagen", "#busqueda", "#campers", "#evaluacion", "#modulos", "#skills"]];
                    verOculatarSeleccion(data4);
                    let data8 = [['#registroTeams'],['#listarTeams']];
                    verOculatarSeleccion(data8)
                    break;

                case 'lstteam':
                    let data7 = [["#teams"], ["#imagen", "#busqueda", "#campers", "#evaluacion", "#modulos", "#skills"]];
                    verOculatarSeleccion(data7);
                    let data9 = [['#listarTeams'],['#registroTeams']];
                    verOculatarSeleccion(data9)
                    break;
                
                case 'rc':
                    let data2 = [["#campers"], ["#imagen", "#busqueda", "#skills", "#evaluacion", "#modulos", "#teams"]];
                    verOculatarSeleccion(data2);
                    let data11 = [['#registroCampers'],['#listarCampers']];
                    verOculatarSeleccion(data11)
                    break;
                
                case 'lstc':
                    let data10 = [["#campers"], ["#imagen", "#busqueda", "#skills", "#evaluacion", "#modulos", "#teams"]];
                    verOculatarSeleccion(data10);
                    let data12 = [['#listarCampers'],['#registroCampers']];
                    verOculatarSeleccion(data12)
                    break;

                case 'rskill':
                    let data3 = [["#skills"], ["#imagen", "#busqueda", "#campers", "#evaluacion", "#modulos", "#teams"]];
                    verOculatarSeleccion(data3);
                    let data13 = [['#registroSkills'],['#listarSkills']];
                    verOculatarSeleccion(data13)
                    break;

                case 'lstskill':
                    let data14 = [["#skills"], ["#imagen", "#busqueda", "#campers", "#evaluacion", "#modulos", "#teams"]];
                    verOculatarSeleccion(data14);
                    let data15 = [['#listarSkills'],['#registroSkills']];
                    verOculatarSeleccion(data15)
                    break;

                case 'rmodulo':
                    let data5 = [["#modulos"], ["#imagen", "#busqueda", "#campers", "#evaluacion", "#teams", "#skills"]];
                    verOculatarSeleccion(data5);
                    let data16 = [['#registroModulosSkill'],['#listarModulosSkill']];
                    verOculatarSeleccion(data16)
                    break;

                case 'lstmodulo':
                    let data17 = [["#modulos"], ["#imagen", "#busqueda", "#campers", "#evaluacion", "#teams", "#skills"]];
                    verOculatarSeleccion(data17);
                    let data18 = [['#listarModulosSkill'],['#registroModulosSkill']];
                    verOculatarSeleccion(data18)
                    break;

                case 'rcc':
                    let data6 = [["#evaluacion"], ["#imagen", "#busqueda", "#campers", "#modulos", "#teams", "#skills"]];
                    verOculatarSeleccion(data6);
                    let data19 = [['#registroEvaluacion'],['#listarEvaluacion']];
                    verOculatarSeleccion(data19)
                    break;

                case 'lstn':
                    let data20 = [["#evaluacion"], ["#imagen", "#busqueda", "#campers", "#modulos", "#teams", "#skills"]];
                    verOculatarSeleccion(data20);
                    let data21 = [['#listarEvaluacion'],['#registroEvaluacion']];
                    verOculatarSeleccion(data21)
                    break;

                case 'cme':
                    let data1 = [["#busqueda"], ["#imagen", "#campers", "#skills", "#evaluacion", "#modulos", "#teams"]];
                    verOculatarSeleccion(data1);
                    break;

                default:
                    let data22 = [["#imagen"], ["#teams", "#busqueda", "#campers", "#evaluacion", "#modulos", "#skills"]];
                    verOculatarSeleccion(data22);
                    break;
            }
            console.log(data);
            e.preventDefault();
            e.stopImmediatePropagation();
        });
    });
}
