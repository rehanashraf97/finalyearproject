<?php
require APPPATH . 'libraries/REST_Controller.php';
     
class Furniture extends REST_Controller {
    
	  /**
     * Get All Data from this method.
     *
     * @return Response
    */
    public function __construct() {
       parent::__construct();
       $this->load->helper('language');
       $this->load->model('Api_model');
       $this->load->library('form_validation');
       $this->load->database();
    }
       
    /**
     * Get All Data from this method.
     *
     * @return Response
    */

 // Creating User 
	public function signup_post()
	{
    $this->form_validation->set_rules('token', 'Token', 'trim|required|callback_checkToken[token]');
    $this->form_validation->set_rules('email', 'Email', 'trim|required|is_unique[users.email]');
    $this->form_validation->set_rules('password', 'Password', 'trim|required');
    $this->form_validation->set_rules('first_name', 'First Name', 'trim|required');
    $this->form_validation->set_rules('last_name', 'Last Name', 'trim|required');
    $this->form_validation->set_rules('type', 'Type', 'trim|required');
    $data = array(
      'status' => 0,
      'code' => -1,
      'msg' => 'Bad Request',
      'data' => null
    );
    if($this->form_validation->run() == TRUE )
      {
        $userInfo = array(
          'email' => $this->input->post('email'),
          'password' => $this->input->post('password'),
          'first_name' => $this->input->post('first_name'),
          'last_name' => $this->input->post('last_name'),
          'type' => $this->input->post('type'),
          'description' => $this->input->post('description')
        );
        $createUser = $this->Api_model->createUser($userInfo);
        if ($createUser === TRUE) {
          $data = array(
            'status' => 1,
            'code' => 1,
            'msg' => 'success',
            'data' => 'User created'
          );
        }else{
          $data = array(
            'status' => 0,
            'code' => -1,
            'msg' => 'Email Already Exist',
            'data' => 'Failed to create user'
          );
        }
      }else
      {
        $data['msg'] = validation_errors();
      }
      $this->response($data, REST_Controller::HTTP_OK);
	  }
  // Creating User End

  // Login User 
  public function login_post()
  {
    $this->form_validation->set_rules('token', 'Token', 'trim|required|callback_checkToken[token]');
    $this->form_validation->set_rules('email', 'Email', 'trim|required');
    $this->form_validation->set_rules('password', 'Password', 'trim|required');
    $data = array(
      'status' => 0,
      'code' => -1,
      'msg' => 'Bad Request',
      'data' => null
    );
    if($this->form_validation->run() == TRUE )
      {
        $email = $this->input->post('email');
        $password = $this->input->post('password');
        $checkUser = $this->Api_model->checkUserExist($email,$password);
        if (isset($checkUser) && !empty($checkUser)) {
          $data = array(
            'status' => 1,
            'code' => 1,
            'msg' => 'success',
            'data' => $checkUser
          );
        }else{
          $data = array(
            'status' => 0,
            'code' => -1,
            'msg' => 'Invalid Email And Password',
            'data' => null
          );
        }
      }else
      {
        $data['msg'] = validation_errors();
      }
      $this->response($data, REST_Controller::HTTP_OK);
    }
  // Login User End 

  // Creating the brand
  public function brand_post()
  {
    $this->form_validation->set_rules('token', 'Token', 'trim|required|callback_checkToken[token]');
    $this->form_validation->set_rules('user_id', 'User id', 'trim|required');
    $this->form_validation->set_rules('name', 'Brand Name', 'trim|required');
    $this->form_validation->set_rules('description', 'Brand Description', 'trim|required');
    $data = array(
      'status' => 0,
      'code' => -1,
      'msg' => 'Bad Request',
      'data' => null
    );
    if($this->form_validation->run() == TRUE )
      {
        $brandInfo = array(
          'u_id' => $this->input->post('user_id'),
          'name' => $this->input->post('name'),
          'description' => $this->input->post('description'),
        );
        $createBrand = $this->Api_model->createBrand($brandInfo);
        if ($createBrand === TRUE) {
          $data = array(
            'status' => 1,
            'code' => 1,
            'msg' => 'success',
            'data' => 'Brand created'
          );
        }else{
          $data = array(
            'status' => 0,
            'code' => -1,
            'msg' => validation_errors(),
            'data' => 'Failed to create Brand'
          );
        }
      }else
      {
        $data['msg'] = validation_errors();
      }
      $this->response($data, REST_Controller::HTTP_OK);
    }
  // Creating the brand End

  // GET the brand
  public function brand_get()
  {
    $token = $_SERVER['HTTP_TOKEN'];
    $user_id = $this->input->get('user_id');
    $data = array(
      'status' => 0,
      'code' => -1,
      'msg' => 'Bad Request',
      'data' => null
    );
    if($this->checkToken($token) === TRUE )
      {
        $getBrand = $this->Api_model->getBrand($user_id);
        if (isset($getBrand)) {
          $data = array(
            'status' => 1,
            'code' => 1,
            'msg' => 'success',
            'data' => $getBrand
          );
        }else{
          $data = array(
            'status' => 1,
            'code' => 1,
            'msg' => 'success',
            'data' => null
          );
        }
      }else
      {
         $data['msg'] = 'Request Unknown or Bad Request';
      }
      $this->response($data, REST_Controller::HTTP_OK);
    }
  // GET the brand End

  // Checking The Token If Valid
  public function checkToken($token)
  {
    if ($token == SECRET_TOKEN) {
      return true;
    }
    return false;
  }
  // Checking The Token If Valid End
    	
}