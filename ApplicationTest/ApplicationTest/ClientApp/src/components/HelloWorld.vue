<template>
<div class="container">

    <div className='row'>
        <div className='col-12'>
          <table className='table table-sm'>
            <thead>
              <tr className='bg-primary text-white'>
                <th>Nombre del empleado</th>
                <th>Apellido del empleado</th>
                <th>Tipo de permiso</th>
                <th>Fecha del permiso</th>
                <th></th>
              </tr>
            </thead>
            <tbody>
                <tr v-for="permit in permits" :key="permit.id">
                  <td className='vertical-aling-center'>Joan Maanuel</td>

                  <td className='vertical-aling-center'>
                  Titin Quezad
                  </td>

                   <td className='vertical-aling-center'>
                  licencia
                  </td>

                  <td>fecha</td>

                  <td className='vertical-aling-center'>
                    <div className='row'>
                      <div className='col'>
                        <button className='btn btn-outline-info mr-3'>
                          <i className='far fa-edit'></i>
                        </button>

                        <button className='btn btn-outline-danger' >
                          <i className='far fa-trash-alt'></i>
                        </button>
                      </div>
                    </div>
                  </td>
                </tr>
           
              <tr>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
                <td></td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>
</div>

</template>

<script>
import  { onMounted } from 'vue'
import axios from 'axios'


export default {
setup() {
onMounted( () => 
{
axios.get('api/permits').then((response) => this.data().permits = response);

})

}
,

  name: 'ajso',
  props: {
    msg: String
  },

 data () { 
    return {permits: [] }
  }
}


</script>


<style scoped>

</style>
